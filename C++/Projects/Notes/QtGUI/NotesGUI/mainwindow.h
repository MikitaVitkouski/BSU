#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QFile>
#include <QString>
#include <QTextEdit>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include "NoteManager.h"
#include "TaskManager.h"
#include <QListWidget>
#include <QListWidgetItem>
#include <QCLoseEvent>
#include <QJsonDocument>
#include <QJsonArray>
#include <QJsonObject>

QT_BEGIN_NAMESPACE
namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    NoteManager manager;
    TaskManager taskManager;
    int editingNoteIndex = -1;
    int editingTaskIndex = -1;
private slots:
    void onbtnRepresentClicked();
    void onbtnAddNoteMenuClicked();
    void onbtnAddNoteClicked();
    void updateListWidgetNotes();
    void onNoteItemDoubleClicked();
    void onbtnAddTaskMenuClicked();
    void onbtnAddTaskClicked();
    void updateListWidgetTasks();
    void onTaskItemDoubleClicked();
    void onbtnRepresentTasksClicked();
protected:
    void closeEvent(QCloseEvent *event) override;
    void keyPressEvent(QKeyEvent *event) override;
};
#endif // MAINWINDOW_H
