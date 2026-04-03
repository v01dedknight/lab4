namespace FileManager.Core {
  // Snapshot (Снимок состояния)
  public class TextMemento {
    public string Content { get; }

    public TextMemento(string content) {
      Content = content;
    }
  }
}