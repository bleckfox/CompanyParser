using HtmlAgilityPack;

namespace Parser
{
    public class ParserWorker
    {
        // URL для загрузки данных
        private readonly string _companiesUrl;
        private readonly string baseUrl = "https://www.list-org.com";
        private readonly string _baseUrlToDownLoad = "https://www.list-org.com/excel_list.php?ids=";

        public ParserWorker(string city, string okved, bool hasPhone, bool hasWebsite, bool hasEmail, bool work = true)
        {
            // Создаем экземпляр строителя
            var builder = new ParserUrlBuilder();

            // Устанавливаем параметры
            _companiesUrl = builder
                .SetCity(city)
                .SetPhone(hasPhone)
                .SetWebsite(hasWebsite)
                .SetEmail(hasEmail)
                .SetWork(work)
                .SetOkved(okved)
                .Build(baseUrl);
        }

        public async Task<bool> DownloadFileAsync(string linkToDownLoadFile, string filePath, HttpClient client, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync(linkToDownLoadFile, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var fileStream = new FileStream(filePath, FileMode.Create);
                await stream.CopyToAsync(fileStream, cancellationToken);

                fileStream.Close();
                stream.Close();

                return true;
            }

            return false;
        }

        public async Task<string> GetLinkToFileAsync(HttpClient client, CancellationToken cancellationToken)
        {
            List<string> companiesIds = new List<string>();

            try
            {
                bool nextPageExists = true;
                int currentPage = 1;
                Random random = new Random();

                while (nextPageExists)
                {
                    await Task.Delay(random.Next(30000, 60000));
                    string content;
                    if (currentPage == 1)
                        content = await client.GetStringAsync(_companiesUrl, cancellationToken);
                    else
                        content = await client.GetStringAsync($"{_companiesUrl}&page={currentPage}", cancellationToken);

                    HtmlDocument htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(content);

                    // Выбираем все элементы <label> внутри класса org_list
                    var labels = htmlDocument.DocumentNode.SelectNodes("//div[@class='org_list']//p//label");

                    // Выводим значение атрибута data-id каждого элемента <label>
                    if (labels != null)
                    {
                        foreach (var label in labels)
                        {
                            // Получаем элемент <input>, если он существует
                            var inputElement = label.SelectSingleNode(".//input");

                            if (inputElement != null)
                            {
                                // Получаем значение атрибута data-id
                                string dataIdValue = inputElement.GetAttributeValue("data-id", string.Empty);

                                // Добавляем значение в список
                                companiesIds.Add(dataIdValue);
                            }
                        }
                    }

                    // Проверяем, есть ли ссылка на следующую страницу
                    currentPage++;
                    
                    var nextPageLinks = htmlDocument.DocumentNode.SelectNodes($"//li[@class='page-item']");
                    
                    nextPageExists = nextPageLinks?.Any(link => link.InnerText == currentPage.ToString()) ?? false;
                }

                
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка при получении данных о компаниях: {e.Message}");
            }

            if (companiesIds.Count > 0)
            {
                return string.Concat(_baseUrlToDownLoad, string.Join(",", companiesIds));
            }
            
            return string.Empty;
        }

        /// <summary>
        /// Метод не используется. Использовался для получения списка компаний для dataGridView
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="client">HttpClient</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Список компаний</returns>
        public async Task<List<string>> LoadPageAsync(int pageNumber, HttpClient client, CancellationToken cancellationToken)
        {
            List<string> CompanyUrls = new List<string>();
            // URL для загрузки данных
            string mainListUrl = "https://www.list-org.com/list?okved2=43.22";
            string mainUrl = "https://www.list-org.com/";

            try
            {
                string content = await client.GetStringAsync($"{_companiesUrl}&page={pageNumber}", cancellationToken);
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(content);

                CompanyUrls.Clear();

                // Выбираем все элементы <p> внутри класса org_list
                var paragraphs = htmlDocument.DocumentNode.SelectNodes("//div[@class='org_list']//p");

                // Выводим текст каждого элемента <p>
                if (paragraphs != null)
                {
                    foreach (var paragraph in paragraphs)
                    {
                        // Проверяем, есть ли у элемента класс "status_0"
                        var statusElement = paragraph.SelectSingleNode(".//span[contains(@class, 'status_0')]");

                        if (statusElement == null)
                        {
                            // Получаем элемент <a>, если он существует
                            var linkElement = paragraph.SelectSingleNode(".//a");
                            if (linkElement != null)
                            {
                                // Получаем значение атрибута href (ссылка)
                                CompanyUrls.Add($"{mainUrl}{linkElement.GetAttributeValue("href", string.Empty)}");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CompanyUrls;
        }


        /// <summary>
        /// Метод не используется. Использовался для получения списка компаний
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Список компаний (как свойство класса)</returns>
        public async Task LoadDataAsync(HttpClient client, CancellationToken cancellationToken)
        {
            // URL для загрузки данных
            string mainListUrl = "https://www.list-org.com/list?okved2=43.22";
            string mainUrl = "https://www.list-org.com/";

            Random random = new Random();
            int page = 0;
            List<string> CompanyUrls = new List<string>();

            for (int i = 1; i < 990; i++)
            {
                page = i;
                try
                {
                    await Task.Delay(random.Next(30000, 60000));
                    string content = await client.GetStringAsync($"{mainListUrl}&page={i}", cancellationToken);
                    HtmlDocument htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(content);

                    // Выбираем все элементы <p> внутри класса org_list
                    var paragraphs = htmlDocument.DocumentNode.SelectNodes("//div[@class='org_list']//p");

                    // Выводим текст каждого элемента <p>
                    if (paragraphs != null)
                    {
                        foreach (var paragraph in paragraphs)
                        {
                            // Проверяем, есть ли у элемента класс "status_0"
                            var statusElement = paragraph.SelectSingleNode(".//span[contains(@class, 'status_0')]");

                            if (statusElement == null)
                            {
                                // Получаем элемент <a>, если он существует
                                var linkElement = paragraph.SelectSingleNode(".//a");
                                if (linkElement != null)
                                {
                                    // Получаем значение атрибута href (ссылка)
                                    CompanyUrls.Add($"{mainUrl}{linkElement.GetAttributeValue("href", string.Empty)}");
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        
    }
}