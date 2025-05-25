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

    //pageAddNoteMenu
    connect(ui->btnAddNote, &QPushButton::clicked, this, &MainWindow::onbtnAddNoteClicked);
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

void MainWindow::updateListWidgetNotes() {

}

void MainWindow::onbtnAddNoteClicked() {
    QString qstr = ui->lineEditTitle->text();
    QString qn = ui->textEditNote->toPlainText();

    if(qstr.isEmpty() || qn.isEmpty()) return;

    std::string title = qstr.toStdString();
    std::string note = qn.toStdString();

    Note newnote(title,note);
    manager.addNote(newnote);

    updateListWidgetNotes();

    ui->lineEditTitle->clear();
    ui->textEditNote->clear();
    ui->notesStackedWidget->setCurrentIndex(0); // back to representation page
}
