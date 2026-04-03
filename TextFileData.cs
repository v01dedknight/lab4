using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileManager.Models {
  [Serializable]
  public class TextFileData {
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime LastModified { get; set; }

    // Пустой конструктор нужен для XML-сериализации
    public TextFileData() { }

    // Конструктор для удобства создания экземпляра
    public TextFileData(string title, string content) {
      Title = title;
      Content = content;
      LastModified = DateTime.Now;
    }

    // Метод для сохранения данных в XML-файл
    public void SaveToXml(string filePath) {
      XmlSerializer serializer = new XmlSerializer(typeof(TextFileData));

      using (StreamWriter writer = new StreamWriter(filePath)) {
        serializer.Serialize(writer, this);
      }
    }

    // Метод для загрузки данных из XML-файла
    public static TextFileData LoadFromXml(string filePath) {
      XmlSerializer serializer = new XmlSerializer(typeof(TextFileData));

      using (StreamReader reader = new StreamReader(filePath)) {
        return (TextFileData)serializer.Deserialize(reader);
      }
    }

    // Метод сохранения в бинарный файл
    public void SaveToBinary(string filePath) {
#pragma warning disable SYSLIB0011
      BinaryFormatter formatter = new BinaryFormatter();

      using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
        formatter.Serialize(fs, this);
      }
    }

    // Метод загрузки из бинарного файла
    public static TextFileData LoadFromBinary(string filePath) {
#pragma warning disable SYSLIB0011
      BinaryFormatter formatter = new BinaryFormatter();

      using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
        return (TextFileData)formatter.Deserialize(fs);
      }
    }
  }
}