#include "mainwindow.h"
#include "./ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QFile file("E:/Repositories/BSU/C++/Projects/Notes/QtGUI/NotesGUI/style.css");
    if (file.open(QFile::ReadOnly | QFile::Text)) {
        QTextStream stream(&file);
        QString styleSheet = stream.readAll();
        this->setStyleSheet(styleSheet);
        file.close();
    }

    //Pages
    connect(ui->btnRepresent, &QPushButton::clicked, this, &MainWindow::onbtnRepresentClicked);
    connect(ui->btnAddNoteMenu, &QPushButton::clicked, this, &MainWindow::onbtnAddNoteMenuClicked);

    ui->notesStackedWidget->setCurrentIndex(0); // by default represent main page with notes
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::onbtnRepresentClicked() {
    ui->notesStackedWidget->setCurrentIndex(0);
}

void MainWindow::onbtnAddNoteMenuClicked() {
    ui->notesStackedWidget->setCurrentIndex(1);
}
