#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "NoteItemWidget.h"
#include <QCoreApplication>
#include <QTextStream>
#include <QDir>
#include "TaskItemWidget.h"
#include <QKeyEvent>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QDir directory = QDir::currentPath();directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();

    QFile fileStyle(basePath + QDir::separator() + "style.css");
    if (fileStyle.open(QFile::ReadOnly | QFile::Text)) {
        QTextStream stream(&fileStyle);
        QString styleSheet = stream.readAll();
        this->setStyleSheet(styleSheet);
        fileStyle.close();
    }

    // Loading notes from file
    QFile fileNotes(basePath + QDir::separator() + "notes.json");
    if (fileNotes.open(QIODevice::ReadOnly)) {
        QByteArray data = fileNotes.readAll();
        fileNotes.close();

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

    // Loading tasks from file
    QFile fileTasks(basePath + QDir::separator() + "tasks.json");
    if (fileTasks.open(QIODevice::ReadOnly)) {
        QByteArray data = fileTasks.readAll();
        fileTasks.close();

        QJsonDocument doc = QJsonDocument::fromJson(data);
        if (doc.isArray()) {
            QJsonArray jsonArray = doc.array();
            for(const auto& val : jsonArray) {
                QJsonObject obj = val.toObject();
                std::string title = obj["title"].toString().toStdString();
                std::vector<std::pair<std::string, bool>> subtasks{};

                if (obj["subtasks"].isArray()) {
                    QJsonArray subtasksArray = obj["subtasks"].toArray();
                    for (const auto& subVal : subtasksArray) {
                        QJsonObject subObj = subVal.toObject();
                        std::string subTitle = subObj["title"].toString().toStdString();
                        bool done = subObj["done"].toBool();
                        subtasks.emplace_back(subTitle, done);
                    }
                }

                Task newTask(title, subtasks);
                taskManager.addTask(newTask);
            }
        }
    }

    updateListWidgetNotes();
    updateListWidgetTasks();
    this->setFocus();

    //Pages
    connect(ui->btnRepresent, &QPushButton::clicked, this, &MainWindow::onbtnRepresentClicked);
    connect(ui->btnAddNoteMenu, &QPushButton::clicked, this, &MainWindow::onbtnAddNoteMenuClicked);
    connect(ui->btnAddTaskMenu, &QPushButton::clicked, this, &MainWindow::onbtnAddTaskMenuClicked);
    connect(ui->btnRepresentTasks, &QPushButton::clicked, this, &MainWindow::onbtnRepresentTasksClicked);

    ui->notesStackedWidget->setCurrentIndex(0); // by default represent main page with notes

    //pageAddNoteMenu
    connect(ui->btnAddNote, &QPushButton::clicked, this, &MainWindow::onbtnAddNoteClicked);
    connect(ui->btnAddTask, &QPushButton::clicked, this, &MainWindow::onbtnAddTaskClicked);

    // doubleClickedOnNote
    connect(ui->listWidgetNotes, &QListWidget::itemDoubleClicked, this, &MainWindow::onNoteItemDoubleClicked);
    connect(ui->listWidgetTasks, &QListWidget::itemDoubleClicked, this, &MainWindow::onTaskItemDoubleClicked);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::onbtnRepresentClicked() {
    ui->notesStackedWidget->setCurrentIndex(0);
}

void MainWindow::onbtnRepresentTasksClicked() {
    ui->notesStackedWidget->setCurrentIndex(3);
}

void MainWindow::onbtnAddNoteMenuClicked() {
    ui->notesStackedWidget->setCurrentIndex(1);
    ui->btnAddNote->setText("Add");
    editingNoteIndex = -1;
}

void MainWindow::onbtnAddTaskMenuClicked() {
    ui->notesStackedWidget->setCurrentIndex(2);
    ui->btnAddTask->setText("Add");
    editingTaskIndex = -1;
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
        ui->listWidgetNotes->setViewMode(QListView::IconMode);
        ui->listWidgetNotes->setFlow(QListView::LeftToRight);
        ui->listWidgetNotes->setWrapping(true); // to move on the next line
        ui->listWidgetNotes->setGridSize(QSize(450, 220)); // size of each element
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
    QDir directory = QDir::currentPath();directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();

    QFile fileNotes(basePath + QDir::separator() + "notes.json");
    if (fileNotes.open(QIODevice::WriteOnly)) {
        QJsonArray jsonArray;
        const auto& notes = manager.getNotes();
        for (const auto& note : notes) {
            QJsonObject obj;
            obj["title"] = QString::fromStdString(note.getTitle());
            obj["note"] = QString::fromStdString(note.getNote());
            jsonArray.append(obj);
        }
        QJsonDocument doc(jsonArray);
        fileNotes.write(doc.toJson());
        fileNotes.close();
    }

    QFile fileTasks(basePath + QDir::separator() + "tasks.json");
    if (fileTasks.open(QIODevice::WriteOnly)) {
        QJsonArray jsonArray;
        const auto& tasks = taskManager.getTasks();
        for (const auto& task : tasks) {
            QJsonObject obj;
            obj["title"] = QString::fromStdString(task.getTitle());
            QJsonArray subtasksArray;
            for(const auto& subtask : task.getSubtasks()) {
                QJsonObject subtaskObj;
                subtaskObj["title"] = QString::fromStdString(subtask.first);
                subtaskObj["done"] = subtask.second;
                subtasksArray.append(subtaskObj);
            }
            obj["subtasks"] = subtasksArray;
            jsonArray.append(obj);
        }

        QJsonDocument doc(jsonArray);
        fileTasks.write(doc.toJson());
        fileTasks.close();
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

void MainWindow::onbtnAddTaskClicked() {
    QString title = ui->lineEditTaskTitle->text();
    QString subtasksText = ui->textEditSubtasks->toPlainText();

    if(title.isEmpty() || subtasksText.isEmpty()) return;

    QStringList subtasksLines = subtasksText.split("\n", Qt::SkipEmptyParts);
    std::vector<std::pair<std::string, bool>> subtasks {};
    for (const QString& line : subtasksLines) {
        subtasks.emplace_back(line.toStdString(), false);
    }

    Task newTask(title.toStdString(), subtasks);

    if (editingTaskIndex == -1) {
        taskManager.addTask(newTask);
    } else {
        taskManager.updateTask(editingTaskIndex, newTask);
        editingTaskIndex = -1;
        ui->btnAddTask->setText("Add");
    }

    updateListWidgetTasks();

    ui->lineEditTaskTitle->clear();
    ui->textEditSubtasks->clear();
    ui->notesStackedWidget->setCurrentIndex(3);
}

void MainWindow::updateListWidgetTasks() {
    ui->listWidgetTasks->clear();

    const auto& tasks = taskManager.getTasks();

    for(int i = 0;i<tasks.size();++i) {
        const Task& task = tasks[i];
        std::vector<std::pair<QString, bool>> qSubtasks;
        for(const auto& st : task.getSubtasks()) {
            qSubtasks.emplace_back(QString::fromStdString(st.first), st.second);
        }

        TaskItemWidget* widget = new TaskItemWidget(
            QString::fromStdString(task.getTitle()),
            qSubtasks
            );

        QListWidgetItem* item = new QListWidgetItem(ui->listWidgetTasks);
        item->setSizeHint(widget->sizeHint());
        ui->listWidgetTasks->addItem(item);
        ui->listWidgetTasks->setItemWidget(item, widget);

        connect(widget, &TaskItemWidget::deleteRequested, this, [this, i]() {
            taskManager.removeTask(i);
            updateListWidgetTasks();
        });

        connect(widget, &TaskItemWidget::editRequested, this, [this, i]() {
            const Task& t = taskManager.getTasks()[i];
            ui->lineEditTaskTitle->setText(QString::fromStdString(t.getTitle()));
            QStringList subLines;
            for (const auto& sub : t.getSubtasks()) {
                subLines << QString::fromStdString(sub.first);
            }
            ui->textEditSubtasks->setText(subLines.join('\n'));

            editingTaskIndex = i;
            ui->notesStackedWidget->setCurrentIndex(2);
            ui->btnAddTask->setText("Save");
        });

        connect(widget, &TaskItemWidget::subtaskToggled, this, [this, i](int subIndex, bool checked) {
            taskManager.updateSubtask(i, subIndex, checked);
        });
    }
}

void MainWindow::onTaskItemDoubleClicked() {
    int row = ui->listWidgetTasks->currentRow();
    const auto& tasks = taskManager.getTasks();
    if (row >= 0 && row < tasks.size()) {
        const Task& task = tasks[row];
        ui->lineEditTaskTitle->setText(QString::fromStdString(task.getTitle()));

        QStringList subLines;
        for (const auto& sub : task.getSubtasks()) {
            subLines << QString::fromStdString(sub.first);
        }
        ui->textEditSubtasks->setText(subLines.join('\n'));

        editingTaskIndex = row;
        ui->notesStackedWidget->setCurrentIndex(2);
        ui->btnAddTask->setText("Save");
    }
}

void MainWindow::keyPressEvent(QKeyEvent *event) {
    if (event->key() == Qt::Key_F5) {
        updateListWidgetNotes();
        updateListWidgetTasks();
    } else if (event->key() == Qt::Key_Escape) {
        ui->notesStackedWidget->setCurrentIndex(0);
    } else if (event->key() == Qt::Key_1){
        ui->notesStackedWidget->setCurrentIndex(0);
    } else if (event->key() == Qt::Key_2){
        ui->notesStackedWidget->setCurrentIndex(1);
    } else if (event->key() == Qt::Key_3){
        ui->notesStackedWidget->setCurrentIndex(2);
    } else if (event->key() == Qt::Key_4){
        ui->notesStackedWidget->setCurrentIndex(3);
    } else {
        QMainWindow::keyPressEvent(event); // if we've pressed not F5
    }
}
