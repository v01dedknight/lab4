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

    public TextFileData() { }

    public TextFileData(string title, string content) {
      Title = title;
      Content = content;
      LastModified = DateTime.Now;
    }

    // XML Сериализация
    public void SaveToXml(string filePath) {
      XmlSerializer serializer = new XmlSerializer(typeof(TextFileData));
      using (StreamWriter writer = new StreamWriter(filePath)) {
        serializer.Serialize(writer, this);
      }
    }

    public static TextFileData LoadFromXml(string filePath) {
      XmlSerializer serializer = new XmlSerializer(typeof(TextFileData));
      using (StreamReader reader = new StreamReader(filePath)) {
        return (TextFileData)serializer.Deserialize(reader);
      }
    }

    // Бинарная сериализация
    public void SaveToBinary(string filePath) {
#pragma warning disable SYSLIB0011
      BinaryFormatter formatter = new BinaryFormatter();
      using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
        formatter.Serialize(fs, this);
      }
    }

    public static TextFileData LoadFromBinary(string filePath) {
#pragma warning disable SYSLIB0011
      BinaryFormatter formatter = new BinaryFormatter();
      using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
        return (TextFileData)formatter.Deserialize(fs);
      }
    }
  }
}