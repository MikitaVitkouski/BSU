#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "NoteItemWidget.h"
#include <QCoreApplication>
#include <QTextStream>
#include <QDir>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QString directory = QCoreApplication::applicationDirPath();
    QFile fileStyle(directory + QDir::separator() "style.css");
    if (fileStyle.open(QFile::ReadOnly | QFile::Text)) {
        QTextStream stream(&fileStyle);
        QString styleSheet = stream.readAll();
        this->setStyleSheet(styleSheet);
        fileStyle.close();
    }

    // Loading notes from file
    QFile file(directory + QDir::separator() + "notes.json");
    if (file.open(QIODevice::ReadOnly)) {
        QByteArray data = file.readAll();
        file.close();

        QJsonDocument doc = QJsonDocument::fromJson(data);
        if (doc.isArray()) {
            QJsonArray jsonArray = doc.array();
            for (const auto& val : jsonArray) {
                QJsonObject obj = val.toObject();
                std::string title = obj["title"].toString().toStdString();
                std::string note = obj["note"].toString().toStdString();

                Note newNote(note, title);
                manager.addNote(newNote);
            }
        }
    }

    updateListWidgetNotes();

    //Pages
    connect(ui->btnRepresent, &QPushButton::clicked, this, &MainWindow::onbtnRepresentClicked);
    connect(ui->btnAddNoteMenu, &QPushButton::clicked, this, &MainWindow::onbtnAddNoteMenuClicked);

    ui->notesStackedWidget->setCurrentIndex(0); // by default represent main page with notes

    //pageAddNoteMenu
    connect(ui->btnAddNote, &QPushButton::clicked, this, &MainWindow::onbtnAddNoteClicked);

    // doubleClickedOnNote
    connect(ui->listWidgetNotes, &QListWidget::itemDoubleClicked, this, &MainWindow::onNoteItemDoubleClicked);
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
    ui->btnAddNote->setText("Add");
    editingNoteIndex = -1;
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

            ui->btnAddNote->setText("Save");
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

        ui->btnAddNote->setText("Add");
    }

    updateListWidgetNotes();

    ui->lineEditTitle->clear();
    ui->textEditNote->clear();
    ui->notesStackedWidget->setCurrentIndex(0); // back to representation page
}

void MainWindow::closeEvent(QCloseEvent *event) {
    QFile file("E:/Repositories/BSU/C++/Projects/Notes/QtGUI/NotesGUI/notes.json");
    if (file.open(QIODevice::WriteOnly)) {
        QJsonArray jsonArray;
        const auto& notes = manager.getNotes();
        for (const auto& note : notes) {
            QJsonObject obj;
            obj["title"] = QString::fromStdString(note.getTitle());
            obj["note"] = QString::fromStdString(note.getNote());
            jsonArray.append(obj);
        }
        QJsonDocument doc(jsonArray);
        file.write(doc.toJson());
        file.close();
    }

    QMainWindow::closeEvent(event);
}

void MainWindow::onNoteItemDoubleClicked() {
    int row = ui->listWidgetNotes->currentRow();
    const auto& notes = manager.getNotes();
    if(row >=0 && row < notes.size()) {
        ui->lineEditTitle->setText(QString::fromStdString(notes[row].getTitle()));
        ui->textEditNote->setText(QString::fromStdString(notes[row].getNote()));
        editingNoteIndex = row;
        ui->notesStackedWidget->setCurrentIndex(1);
        ui->btnAddNote->setText("Save");
    }
}
