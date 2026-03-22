# Laboratory Work №4: Standard I/O, Serialization, and Memento Pattern

### Author
**Me**

**Variant:** Text File Management & Indexing System

---

### Objective
Exploration of standard I/O operations in C#, including binary and XML serialization. Implementation of advanced file searching algorithms and the Memento design pattern for state management in a console-based editor.

---

### Project Structure
* **Program.cs:** Main entry point featuring the console editor, file indexing demonstration, and search functionality.
* **TextFile.cs:** Core class representing a text file with built-in serialization and deserialization logic.
* **FileIndexer.cs:** Service for directory scanning and keyword-based file indexing.
* **EditorHistory.cs:** Implementation of the Memento pattern to facilitate "Undo" operations.
* **lab4.csproj:** Modern SDK-style project file configured for .NET Framework 4.7.2.

---

### Coding Standards Applied
* **Indentation:** Strictly 2 spaces (no tabs).
* **Naming Convention:** lowerCamelCase for variables and local properties.
* **Logic Separation:** Explicit separation between I/O operations, serialization logic, and UI rendering.
* **State Management:** Use of the Memento pattern to capture and restore object states without violating encapsulation.
* **Data Persistence:** Support for both Binary and XML formats to ensure cross-platform data compatibility.

---

### Key Features
* **Serialization:** Deep saving and loading of objects using BinaryFormatter and XmlSerializer.
* **Keyword Search:** Robust engine for locating specific text files within complex directory structures.
* **Console Editor:** A functional text editor interface with real-time input handling.
* **Undo/Redo:** Reliable version control for text edits based on the Memento pattern.
* **Directory Indexing:** Automated scanning of folders to build a searchable index of keywords.

---

### How to Run
1.  **Environment**: Ensure you have .NET SDK installed (compatible with .NET Framework 4.7.2 targets).
2.  **Navigate**: Open your terminal in the project folder: `cd lab_04`.
3.  **Clean (Optional)**: `dotnet clean lab4.csproj`.
4.  **Run**: Execute the application using:
    ```powershell
    dotnet run --project lab4.csproj
    ```