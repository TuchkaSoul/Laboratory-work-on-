using HashTableCollection;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using UserLibraryProductionShop;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace WinFormsApp1
{

    internal class SerializationHahtable
    {
        List<Production> result;
        string FileName;
        public SerializationHahtable(string FileName)
        {
            this.FileName = FileName;
        }


        #region Синхронные методы

        internal void Serialize(HahTable<Production> table)
        {
            Dictionary<string, Action<HahTable<Production>>> serializationMethods = new Dictionary<string, Action<HahTable<Production>>>{
                { ".txt", SerializeToTxtFile },
                { ".bin", SerializeToBinaryFile },
                { ".xml", SerializeToXmlFile },
                { ".json", SerializeToJsonFile }
            };
            string fileExtension = Path.GetExtension(FileName);
            if (serializationMethods.TryGetValue(fileExtension, out Action<HahTable<Production>> method))
            {
                method(table);
            }
            else
            {
                throw new ArgumentException("Неподдерживаемое расширение файла", nameof(fileExtension));
            }
        }

        internal List<Production> Deserialize(string filePath)
        {
            Dictionary<string, Func<List<Production>>> deserializationMethods = new Dictionary<string, Func<List<Production>>>{
            { ".txt", DeserializeFromTxtFile },
            { ".bin", DeserializeFromBinaryFile },
            { ".xml", DeserializeFromXmlFile },
            { ".json", DeserializeFromJsonFile }
            };
            string fileExtension = Path.GetExtension(FileName);
            if (deserializationMethods.TryGetValue(fileExtension, out Func<List<Production>> method))
            {
                return method();
            }
            else
            {
                throw new ArgumentException("Неподдерживаемое расширение файла", nameof(fileExtension));
            }
        }


        #region BINARY
        public void SerializeToBinaryFile(string filePath, HahTable<Production> data)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, data.ToList());
            }
        }
        public void SerializeToBinaryFile(HahTable<Production> data)
        {
            SerializeToBinaryFile(FileName, data);

        }
        public List<Production> DeserializeFromBinaryFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Production>)formatter.Deserialize(fileStream);
            }
        }
        public List<Production> DeserializeFromBinaryFile()
        {
            return DeserializeFromBinaryFile(FileName);
        }
        #endregion

        #region TXT
        public void SerializeToTxtFile(string filePath, HahTable<Production> data)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var item in data)
                {
                    writer.WriteLine($"{item.ToTXTString()} ");
                }
                writer.Close();
            }
        }

        public void SerializeToTxtFile(HahTable<Production> data)
        {
            SerializeToTxtFile(FileName, data);
        }

        public List<Production> DeserializeFromTxtFile(string filePath)
        {
            result = new List<Production>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    result.Add(line.ParseClass());
                }
                reader.Close();
            }
            return result;
        }

        public List<Production> DeserializeFromTxtFile()
        {
            return DeserializeFromTxtFile(FileName);
        }
        #endregion

        #region XML
        public List<Production> DeserializeFromXmlFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Production>), new Type[] { typeof(Factory), typeof(Workshop), typeof(Shop) });
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (List<Production>)serializer.Deserialize(reader)!;
            }
        }
        public List<Production> DeserializeFromXmlFile()
        {
            return DeserializeFromXmlFile(FileName);
        }


        public void SerializeToXmlFile(HahTable<Production> data)
        {
            SerializeToXmlFile(FileName, data);
        }
        public void SerializeToXmlFile(string filePath, HahTable<Production> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Production>), new Type[] { typeof(Factory), typeof(Workshop), typeof(Shop) });
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data.ToList());
            }
        }
        #endregion

        #region JSON

        public void SerializeToJsonFile(HahTable<Production> table)
        {
            SerializeToJsonFile(FileName, table);
        }
        public void SerializeToJsonFile(string filePath, HahTable<Production> table)
        {
            string json = JsonConvert.SerializeObject(table.ToList(), Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects, // Включение информации о типах
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(filePath, json);
        }
        public List<Production> DeserializeFromJsonFile(string filePath)
        {
            result = new List<Production>();
            try
            {
                string json = File.ReadAllText(filePath);
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
                result = JsonConvert.DeserializeObject<List<Production>>(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result!; // Возвращаем null, если произошла ошибка
            }

        }
        public List<Production> DeserializeFromJsonFile()
        {
            DeserializeFromJsonFile(FileName);
            return result;
        }
        #endregion

        #endregion


        #region Асинхронные методы

        public void SerializeAsync(HahTable<Production> table)
        {
            Dictionary<string, Action<HahTable<Production>>> serializationMethods = new Dictionary<string, Action<HahTable<Production>>>
    {
        { ".txt", SerializeToTxtFileAsync },
        { ".bin", SerializeToBinaryFileAsync },
        { ".xml", SerializeToXmlFileAsync },
        { ".json", SerializeToJsonFileAsync }
    };
            string fileExtension = Path.GetExtension(FileName);
            if (serializationMethods.TryGetValue(fileExtension, out Action<HahTable<Production>> method))
            {
                method(table);
            }
            else
            {
                throw new ArgumentException("Неподдерживаемое расширение файла", nameof(fileExtension));
            }
        }

        public async Task<List<Production>> DeserializeAsync(string filePath)
        {
            Dictionary<string, Func<Task<List<Production>>>> deserializationMethods = new Dictionary<string, Func<Task<List<Production>>>>()
    {
        { ".txt", DeserializeFromTxtFileAsync },
        { ".bin", DeserializeFromBinaryFileAsync },
        { ".xml", DeserializeFromXmlFileAsync },
        { ".json", DeserializeFromJsonFileAsync }
    };
            string fileExtension = Path.GetExtension(FileName);
            if (deserializationMethods.TryGetValue(fileExtension, out Func<Task<List<Production>>> method))
            {
                return await method();
            }
            else
            {
                throw new ArgumentException("Неподдерживаемое расширение файла", nameof(fileExtension));
            }
        }



        #region BINARY ASYNC

        public async void SerializeToBinaryFileAsync(string filePath, HahTable<Production> data)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                await System.Threading.Tasks.Task.Run(() => formatter.Serialize(fileStream, data.ToList()));
                fileStream.Close();
            }
            //using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    await fileStream.WriteAsync(BitConverter.GetBytes(data.ToList().Count));
            //    foreach (var item in data)
            //    {
            //        using (MemoryStream memoryStream = new MemoryStream())
            //        {
            //            formatter.Serialize(memoryStream, item);
            //            await fileStream.WriteAsync(memoryStream.ToArray());
            //        }
            //    }
            //}
        }

        public async void SerializeToBinaryFileAsync(HahTable<Production> data)
        {
            SerializeToBinaryFileAsync(FileName, data);
        }

        public async Task<List<Production>> DeserializeFromBinaryFileAsync(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var a = (List<Production>)await System.Threading.Tasks.Task.Run(() => formatter.Deserialize(fileStream));
                fileStream.Close();
                return a;
            }
            //using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    byte[] buffer1 = new byte[sizeof(int)];
            //    int bytesRead1 = await fileStream.ReadAsync(buffer1, 0, sizeof(int));
            //    int count = BitConverter.ToInt32(buffer1, 0);
            //    List<Production> result = new List<Production>(count);
            //    for (int i = 0; i < count; i++)
            //    {
            //        using (MemoryStream memoryStream = new MemoryStream())
            //        {
            //            int bytesRead = 0;
            //            byte[] buffer = new byte[1024];
            //            while (bytesRead < buffer.Length)
            //            {
            //                int read = await fileStream.ReadAsync(buffer, bytesRead, buffer.Length - bytesRead);
            //                if (read == 0) break;
            //                bytesRead += read;
            //            }
            //            memoryStream.Write(buffer, 0, bytesRead);
            //            memoryStream.Position = 0;
            //            memoryStream.Position = 0;
            //            formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            //            object obj = formatter.Deserialize(memoryStream);
            //            result.Add((Production)obj);
            //        }
            //    }
            //    return result;
            //}

        }

        public async Task<List<Production>> DeserializeFromBinaryFileAsync()
        {
            return await DeserializeFromBinaryFileAsync(FileName);
        }

        #endregion

        #region TXT ASYNC

        public async void SerializeToTxtFileAsync(string filePath, HahTable<Production> data)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var item in data)
                {
                    await writer.WriteLineAsync($"{item.ToTXTString()} ");
                }
                writer.Close();
            }

        }


        public async Task<List<Production>> DeserializeFromTxtFileAsync(string filePath)
        {
            result = new List<Production>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    result.Add(line.ParseClass());
                }
                reader.Close();
            }
            return result;
        }
        public async void SerializeToTxtFileAsync(HahTable<Production> data)
        {
            SerializeToTxtFileAsync(FileName, data);
        }


        public async Task<List<Production>> DeserializeFromTxtFileAsync()
        {
            return await DeserializeFromTxtFileAsync(FileName);
        }

        #endregion

        #region XML ASYNC

        public async Task<List<Production>> DeserializeFromXmlFileAsync(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Production>), new Type[] { typeof(Factory), typeof(Workshop), typeof(Shop) });
            using (StreamReader reader = new StreamReader(filePath))
            {
                var a = await System.Threading.Tasks.Task.Run(() => serializer.Deserialize(reader)) as List<Production>;
                reader.Close();
                return a;
            }
        }

        public async Task<List<Production>> DeserializeFromXmlFileAsync()
        {
            return await DeserializeFromXmlFileAsync(FileName);
        }

        public async void SerializeToXmlFileAsync(string filePath, HahTable<Production> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Production>), new Type[] { typeof(Factory), typeof(Workshop), typeof(Shop) });
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await System.Threading.Tasks.Task.Run(() => serializer.Serialize(writer, data.ToList()));
                writer.Close();

            }
        }

        public async void SerializeToXmlFileAsync(HahTable<Production> data)
        {
            SerializeToXmlFileAsync(FileName, data);
        }

        #endregion

        #region JSON ASYNC

        public async void SerializeToJsonFileAsync(string filePath, HahTable<Production> data)
        {
            SerializeToJsonFile(filePath, data);
        }
        public async Task<List<Production>> DeserializeFromJsonFileAsync(string filePath)
        {
            
            return DeserializeFromJsonFile();
        }
        public async void SerializeToJsonFileAsync(HahTable<Production> table)
        {
            SerializeToJsonFileAsync(FileName, table);
        }

        public async Task<List<Production>> DeserializeFromJsonFileAsync()
        {
            return await DeserializeFromJsonFileAsync(FileName);
        }

        #endregion
        #endregion

        #region Тесты времени
        public List<long> MeasureSerializationTime(HahTable<Production> data)
        {
            string filePath = Path.GetDirectoryName(FileName)!;
            List<long> ticks = new List<long>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SerializeToTxtFile(filePath + "\\1.txt", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            SerializeToBinaryFile(filePath + "\\2.bin", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            SerializeToXmlFile(filePath + "\\3.xml", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            SerializeToJsonFile(filePath + "\\4.json", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            return ticks;
        }
        public List<long> MeasureDeserializationTime()
        {
            string filePath = Path.GetDirectoryName(FileName)!;

            List<long> ticks = new List<long>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            DeserializeFromTxtFile(filePath + "\\1.txt");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            DeserializeFromBinaryFile(filePath + "\\2.bin");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            DeserializeFromXmlFile(filePath + "\\3.xml");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            DeserializeFromJsonFile(filePath + "\\4.json");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            return ticks;
        }

        public List<long> MeasureSerializationTimeAsync(HahTable<Production> data)
        {
            string filePath = Path.GetDirectoryName(FileName)!;
            List<long> ticks = new List<long>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SerializeToTxtFileAsync(filePath + "\\1.txt", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);


            stopwatch.Restart();
            SerializeToBinaryFileAsync(filePath + "\\2.bin", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            SerializeToXmlFileAsync(filePath + "\\3.xml", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            SerializeToJsonFileAsync(filePath + "\\4.json", data);
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            return ticks;
        }
        public async Task<List<long>> MeasureDeserializationTimeAsync()
        {
            string filePath = Path.GetDirectoryName(FileName)!;

            List<long> ticks = new List<long>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await DeserializeFromTxtFileAsync(filePath + "\\1.txt");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            await DeserializeFromBinaryFileAsync(filePath + "\\2.bin");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            await DeserializeFromXmlFileAsync(filePath + "\\3.xml");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            await DeserializeFromJsonFileAsync(filePath + "\\4.json");
            stopwatch.Stop();
            ticks.Add(stopwatch.ElapsedTicks);

            return ticks;
        }
        #endregion

    }
}
