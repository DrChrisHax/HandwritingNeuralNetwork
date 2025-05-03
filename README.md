# Handwriting Neural Network (CPSC 362 Project)

## Team 4
- **Chris Manlove**
- **Steve Truong**
- **Ezra Gale**

---

## Project Description
Handwriting Neural Network is a C#-based application that allows users to **draw handwritten digits**, which are then classified by a **custom neural network** model.  

The program provides two main modes:
- **User Account**:  
  - Draw digits on a 16×16 grid.
  - View model analysis output.
- **Admin Account**:  
  - Same as user account features.
  - Plus: Access a **training interface** to train and save the neural network model.

The goal was to create a complete, functional AI system including front-end (WinForms GUI), backend (SQL Server database), and AI (custom-built neural network for digit recognition).

---

## Technologies Used
- **C# (.NET Framework)**
- **WinForms** for the GUI
- **MS SQL Server** for database management
- **Custom Neural Network** implemented from scratch
- **SQL Scripts** for database schema and initialization
- **Entity interaction** via a direct SQL connection using good practices

---

## Features

| Feature | User | Admin |
|:---|:---|:---|
| Create an account | ✅ | ✅ |
| Login | ✅ | ✅ |
| Draw numbers for analysis | ✅ | ✅ |
| View classification results | ✅ | ✅ |
| Train the neural network | ❌ | ✅ |
| Save and deploy trained models | ❌ | ✅ |

---

## Neural Network Model

The **NeuralNetwork2** class implements a fully-connected, feed-forward neural network with backpropagation and stochastic gradient descent (SGD) training.  

Key Points:
- Layers are customizable.
- Weights and biases are initialized with Gaussian distribution.
- Training supports mini-batch learning for efficiency.
- Activation function: **Sigmoid**.
- Training progress is logged with timestamps for analysis.

Training can be initiated through the Admin UI and monitored via real-time updates.

---

## How to Run

1. Ensure **MS SQL Server** is installed and running locally.
2. Clone the repository.
3. Build the solution in Visual Studio.
4. Run the project to launch the login window.
5. Initialize the database if prompted (handled automatically if first launch).
6. Create an account or login as an Admin to access the training interface.

---

## Notes
- The database and application are currently **configured for local machine** use.
- Neural Network code was written to **highlight AI concepts**, focusing on clarity and training control.
- This project was completed as part of **CPSC 362 - Software Engineering**.

---
