#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "NoteItemWidget.h"

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
    ui->listWidgetNotes->clear();
    const std::vector<Note>& notes = manager.getNotes();

    for(int i = 0;i<notes.size();++i) {
        const auto& note = notes[i];
        QListWidgetItem* item = new QListWidgetItem(ui->listWidgetNotes);
        NoteItemWidget* widget = new NoteItemWidget(
            QString::fromStdString(note.getTitle()),
            QString::fromStdString(note.getNote())
            );

        connect(widget, &NoteItemWidget::deleteRequested, this, [this,index = i]() {
            manager.removeNote(index);
            updateListWidgetNotes();
        });

        connect(widget, &NoteItemWidget::editRequested, this, [this, i]() {
            const auto& notes = manager.getNotes();
            ui->lineEditTitle->setText(QString::fromStdString(notes[i].getTitle()));
            ui->textEditNote->setText(QString::fromStdString(notes[i].getNote()));
            editingNoteIndex = i;
            ui->notesStackedWidget->setCurrentIndex(1);
        });

        item->setSizeHint(widget->sizeHint());
        ui->listWidgetNotes->addItem(item);
        ui->listWidgetNotes->setItemWidget(item, widget);
    }
}

void MainWindow::onbtnAddNoteClicked() {
    QString qstr = ui->lineEditTitle->text();
    QString qn = ui->textEditNote->toPlainText();

    if(qstr.isEmpty() || qn.isEmpty()) return;

    std::string title = qstr.toStdString();
    std::string note = qn.toStdString();

    Note newnote(note,title);

    if (editingNoteIndex == -1) {
        manager.addNote(newnote);
    } else {
        manager.updateNote(editingNoteIndex, newnote);
        editingNoteIndex = -1;
    }

    updateListWidgetNotes();

    ui->lineEditTitle->clear();
    ui->textEditNote->clear();
    ui->notesStackedWidget->setCurrentIndex(0); // back to representation page
}
