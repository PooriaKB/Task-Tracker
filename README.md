# 🧾 Task Tracker

A **console-based Task Tracker app** built with **.NET** that helps you manage your tasks directly from the command line.

---

## 🚀 Overview

This is a simple **Command-Line Interface (CLI)** app designed to help you:

- Keep track of what needs to be done  
- Record what you’re currently working on  
- Log what you’ve completed  

All tasks can be **saved as a JSON file** for persistence.

---

## 🧱 Task Properties

Each task contains the following information:

| Property | Description |
|-----------|--------------|
| **ID** | Unique identifier for the task |
| **Description** | The content of the task |
| **Status** | Current state (`Todo`, `In Progress`, or `Done`) |
| **Created At** | Timestamp when the task was created |
| **Updated At** | Timestamp when the task was last modified |

---

## ⚙️ Features

You can perform the following actions:

1. ➕ **Add a Task**  
2. ✏️ **Update a Task**  
3. ❌ **Delete a Task**  
4. ✅ **Mark a Task as Done or In Progress**  
5. 📋 **Show the Tasks List**  
6. 🧹 **Clear the Tasks List**  
7. 💾 **Save Tasks as JSON**  
8. 🚪 **Exit the App**

---

## 🧩 Feature Details

### 1. ➕ Add a Task
- You’ll be prompted to enter a **task description**.  
- ⚠️ **Description cannot be empty** — the app will remind you if it is.

### 2. ✏️ Update a Task
- Enter the **ID** of the task you want to update.  
- Provide a new **description** for the task.  
- ⚠️ The description cannot be empty.

### 3. ❌ Delete a Task
- Provide the **ID** of the task you wish to remove.  
- The task will be deleted from the list.

### 4. ✅ Mark a Task as Done or In Progress
- Enter the **ID** of the task.  
- Choose between:
  - ✅ **Done**  
  - 🔄 **In Progress**  
- The task’s status will be updated accordingly.

### 5. 📋 Show the Tasks List
- View all tasks or filter by status:
  1. All Tasks  
  2. Todo  
  3. In Progress  
  4. Done

### 6. 🧹 Clear the Tasks List
- Clears **all tasks** from the list.  
- A confirmation prompt ensures you don’t delete them by mistake.

### 7. 💾 Save File as JSON
- Saves all tasks to a **JSON file** located in the `/Tasks` folder at the project root.

### 8. 🚪 Exit the App
- Closes the application after a confirmation prompt.

---

## 🛠️ Technologies Used

- **.NET (C#)**
- **System.Text.Json** for serialization
- **Console interface** for interaction

---

## 📜 License

This project is open-source and available under the [MIT License](LICENSE).
