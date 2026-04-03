using System.Collections.Generic;

namespace FileManager.Core {
  // Caretaker (Хранитель истории)
  public class EditorHistory {
    // Стек для хранения снимков состояния
    private Stack<TextMemento> _history = new Stack<TextMemento>();

    // Сохранение состояния
    public void Push(TextMemento memento) {
      _history.Push(memento);
    }

    // Получение последнего сохраненного состояния
    public TextMemento Pop() {
      if (_history.Count > 0) {
        return _history.Pop();
      }
      else {
        return null;
      }
    }

    // Проверка, есть ли сохраненные состояния
    public bool IsEmpty {
      // Если стек пуст, вернёт true
      get {
        return _history.Count == 0;
      }
    }
  }
}