using System;
using System.IO;
using FileManager.Models;
using FileManager.Services;
using FileManager.Core;

TextFileData currentFile = new TextFileData("NewDocument", "");
EditorHistory history = new EditorHistory();

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