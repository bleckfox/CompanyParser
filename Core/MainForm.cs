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

    }
}
