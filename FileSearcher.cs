using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager.Services {
  public class FileSearcher {
    public List<string> FindFilesByKeyword(string directoryPath, string keyword) {
      var results = new List<string>();
      if (!Directory.Exists(directoryPath)) return results;

      // В массив попадают все .txt файлы в директории
      string[] files = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

      foreach (var file in files) {
        // Для простых текстовых файлов
        if (File.ReadAllText(file).Contains(keyword)) {
          results.Add(file);
        }
      }
      return results;
    }

    public void IndexDirectory(string path, string[] keywords) {
      // Вывод в консоль найденных связей (по сути упрощённая сериализация)
      foreach (var word in keywords) {
        var matches = FindFilesByKeyword(path, word);
        Console.WriteLine($"Ключевое слово [{word}]: найдено в {matches.Count} файлах.");
        matches.ForEach(m => Console.WriteLine($" - {Path.GetFileName(m)}"));
      }
    }
  }
}