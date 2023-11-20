using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Models;
using Parser;

namespace Core
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource? cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();

            // Получение абсолютного пути к файлу
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "okved.json");

            // Создаем объект JsonSerializerOptions с установленным PropertyNamingPolicy
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                // Другие опции, если необходимо
            };

            // Десериализация JSON в список объектов
            List<TreeNodeData>? treeData = JsonSerializer.Deserialize<List<TreeNodeData>>(File.ReadAllText(filePath), options);

            if (treeData == null)
                MessageBox.Show("Не найден файл с кодами ОКВЭД. Попробуйте найти его или переустановить программу");

            CreateTreeView(treeData!, codesTreeView);
        }

        private void CreateTreeView(List<TreeNodeData> treeData, TreeView treeView)
        {
            treeView.Nodes.Clear();

            foreach (var nodeData in treeData)
            {
                TreeNode rootNode = new TreeNode($"{nodeData.Code}-{nodeData.Name}");

                AddNodes(rootNode, nodeData.Items);

                treeView.Nodes.Add(rootNode);
            }
        }

        private void AddNodes(TreeNode parentNode, List<TreeNodeData> items)
        {
            if (items == null) return;

            foreach (var item in items)
            {
                TreeNode node = new TreeNode($"{item.Code}-{item.Name}");
                
                AddNodes(node, item.Items);
                
                parentNode.Nodes.Add(node);
            }
        }

        private async void findAndLoadBtn_Click(object sender, EventArgs e)
        {
            executionLabel.Text = "Работаю";

            DateTime start = DateTime.Now;

            // Очищаем старые ресурсы
            cancellationTokenSource?.Dispose();
            // Создаем новый CancellationTokenSource
            cancellationTokenSource = new CancellationTokenSource();

            if (cityComboBox.SelectedItem == null)
            {
                cityComboBox.SelectedIndex = 0;
            }

            ParserWorker parser = new ParserWorker(
                cityComboBox.Text,
                codesRichTextBox.Text.Replace("  ", "").TrimEnd(','),
                hasPhoneCheckBox.Checked,
                hasWebsiteCheckBox.Checked,
                hasEmailCheckBox.Checked
            );

            using (HttpClient client = new HttpClient())
            {
                string linkToDownLoadFile = await parser.GetLinkToFileAsync(client, cancellationTokenSource.Token);

                if (!string.IsNullOrEmpty(linkToDownLoadFile))
                {
                    // Скачивание файла

                    try
                    {
                        // Открываем диалоговое окно для выбора места сохранения файла
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        saveFileDialog.Title = "Save As";
                        saveFileDialog.FileName = $"{cityComboBox.Text}_компании.xlsx"; // Имя по умолчанию

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохраняем файл по указанному пути
                            var isLoaded = await parser.DownloadFileAsync(linkToDownLoadFile, saveFileDialog.FileName, client, cancellationTokenSource.Token);

                            if (isLoaded)
                                MessageBox.Show("Файл успешно скачан и сохранен.");
                            else
                                MessageBox.Show("Во время сохранения что-то пошло не так. Это странно. Попробуйте снова чуть позже.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при скачивании файла: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"Не удалось скачать информацию. Попробуйте открыть сайт вручную и проверить доступен ли сайт.");
                }
            }


            DateTime end = DateTime.Now;

            executionLabel.Text = "Жду запуск";

            startWorkTimeLabel.Text = start.ToString(@"hh\:mm\:ss\.fff");
            endWorkTimeLabel.Text = end.ToString(@"hh\:mm\:ss\.fff");
            difWorkTimeLabel.Text = (end - start).ToString(@"hh\:mm\:ss\.fff");

        }

        private void addCodeBtn_Click(object sender, EventArgs e)
        {
            var code = codesTreeView.SelectedNode.Text.Split("-")[0];
            if (Regex.IsMatch(code, @"^[0-9.]+$"))
                codesRichTextBox.AppendText($"{code},  ");
        }

        //private async void loadBtn_Click(object sender, EventArgs e)
        //{
        //    DateTime start = DateTime.Now;

        //    // Очищаем старые ресурсы
        //    cancellationTokenSource?.Dispose();

        //    // Создаем новый CancellationTokenSource
        //    cancellationTokenSource = new CancellationTokenSource();

        //    Random random = new Random();

        //    int numberRows = companyDataGridView.Rows.Count > 0 ? companyDataGridView.Rows.Count + 1 : 1;

        //    //using (HttpClient client = new HttpClient())
        //    //{
        //    //    for (int page = Convert.ToInt32(viewedPageLabel.Text) + 1; page < 990; page++)
        //    //    {
        //    //        // иногда нужно вручную проходить reCaptcha
        //    //        // сделать проверку, что список не пополняется и приостановить загрузку до прохождения reCaptcha

        //    //        DateTime startIteration = DateTime.Now;

        //    //        // задержка нужно для того, чтобы избежать блокировки, из-за слишком частых запросов
        //    //        await Task.Delay(random.Next(30000, 120000));

        //    //        // Задержка после startIteration покажет время между запросами

        //    //        var companies = await ParserWorker.LoadPageAsync(page, client, cancellationTokenSource.Token);

        //    //        companies.ForEach(company =>
        //    //        {
        //    //            numberRows++;
        //    //            companyDataGridView.Rows.Add(
        //    //                numberRows,
        //    //                page,
        //    //                (DateTime.Now - startIteration).ToString(@"hh\:mm\:ss\.fff"),
        //    //                company
        //    //            );
        //    //        });

        //    //        viewedPageLabel.Text = page.ToString();
        //    //        companyCountLabel.Text = companyDataGridView.Rows.Count.ToString();
        //    //    }
        //    //}

        //    executionTimeLabel.Text = (DateTime.Now - start).ToString(@"hh\:mm\:ss\.fff");
        //}

        //private void saveToTxtBtn_Click(object sender, EventArgs e)
        //{
        //    //CopyListViewItemsToFile(companyUrlsListBox);
        //    // Ссылка на скачивание
        //    string downloadUrl = "https://www.list-org.com/excel_list.php?ids=35497,131384,145398,147027,174635,2691102,3487096,4396111,4396915,4397800,5070502,5544872,6229363,6249210,6385271,6450794,6548302,6574618,6762798,6778151,11562693,11571099,11619644,11635397,11646005,11646168,11651858,11655428,11676701,11762355,11765563,11771647,11773504,11788478,11805908,11810373,11811125,11813537,11833825,11892741,11923282,11928113,11939191,11939729,11941203,11947487,11987609,11989007,11994986,12027093,12042378";

        //    using (WebClient client = new WebClient())
        //    {
        //        try
        //        {
        //            // Открываем диалоговое окно для выбора места сохранения файла
        //            SaveFileDialog saveFileDialog = new SaveFileDialog();
        //            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        //            saveFileDialog.Title = "Save As";
        //            saveFileDialog.FileName = "yourfile.xlsx"; // Имя по умолчанию

        //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                // Сохраняем файл по указанному пути
        //                client.DownloadFile(downloadUrl, saveFileDialog.FileName);

        //                MessageBox.Show("Файл успешно скачан и сохранен.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Ошибка при скачивании файла: {ex.Message}");
        //        }
        //    }
        //}

        //private void CopyListViewItemsToFile(ListBox listBox)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (var item in listBox.Items)
        //    {
        //        int number = 1;
        //        sb.AppendLine($"{number++}\t-\t{item.ToString()}\n");
        //    }

        //    // Дописывание в файл
        //    WriteToFile(sb.ToString());
        //}

        //private void WriteToFile(string content)
        //{
        //    try
        //    {
        //        // Путь к рабочему столу пользователя
        //        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //        // Полный путь к файлу на рабочем столе
        //        string fullPath = Path.Combine(desktopPath, "list_of_companies.txt");

        //        // Дописывание в файл
        //        File.AppendAllText(fullPath, content);

        //        MessageBox.Show("Запись успешно выполнена!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
        //    }
        //}

        //private void stopLoadBtn_Click(object sender, EventArgs e)
        //{
        //    // Отменяем операцию, если она запущена
        //    cancellationTokenSource?.Cancel();
        //}
    }
}
