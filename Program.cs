using System;
using System.IO;
using FileManager.Models;
using FileManager.Services;
using FileManager.Core;

// Элементы меню
string inputComand = "";
string textForFile = "";
string word = "";

// Экземпляры для проверки
TextFileData currentFile = new TextFileData("NewDocument", "");
EditorHistory history = new EditorHistory();
FileSearcher searcher = new FileSearcher();

Console.WriteLine("Консольный редактор\n"+
  "Команды: 'add [текст]', 'undo', 'save', 'search', 'exit'");

// Меню
while (true) {
  Console.Write("\n> ");
  inputComand = Console.ReadLine();

  // StartsWith используется для проверки, начинается ли строка с определенного текста
  if (inputComand.StartsWith("add ")) {
    textForFile = inputComand.Substring(4);
    AddText(textForFile);
    Console.WriteLine($"Добавлено. Текущий текст: {currentFile.Content}");
  }
  else if (inputComand == "undo") {
    Undo();
    Console.WriteLine($"Откат выполнен. Текущий текст: {currentFile.Content}");
  }
  else if (inputComand == "save") {
    currentFile.SaveToXml("document.xml");
    Console.WriteLine("Файл сохранен в XML (document.xml)");
  }
  else if (inputComand == "search") {
    Console.Write("Введите ключевое слово для поиска в текущей папке: ");
    word = Console.ReadLine();
    searcher.IndexDirectory(Directory.GetCurrentDirectory(), new[] { word });
  }
  else if (inputComand == "exit") {
    break;
  }
  else {
    Console.WriteLine("Неизвестная команда.");
  }
}

// Логика добавления
void AddText(string newText) {
  // Сначала сохраняется старое состояние, затем вносятся изменения
  history.Push(new TextMemento(currentFile.Content));
  currentFile.Content += newText;
}

// Отмена изменений
void Undo() {
  var previous = history.Pop();

  // Если есть сохраненное состояние, оно восстанавливается
  if (previous != null) {
    currentFile.Content = previous.Content;
  }
}