#ifndef TASKITEMWIDGET_H
#define TASKITEMWIDGET_H

#pragma once

#include <QWidget>
#include <QLabel>
#include <QCheckBox>
#include <QPushButton>
#include <QVBoxLayout>
#include <QString>
#include <vector>
#include <QFrame>
#include <QHBoxLayout>
#include <QStyle>

class TaskItemWidget : public QWidget {
    Q_OBJECT
public:
    TaskItemWidget(const QString& title, const std::vector<std::pair<QString, bool>>& subtasks, QWidget* parent = nullptr);
    void updateSubtaskState(int index, bool checked);
    bool isCompleted() const;

signals:
    void editRequested();
    void deleteRequested();
    void subtaskToggled(int index, bool checked);

private:
    QLabel* titleLabel;
    std::vector<QCheckBox*> checkboxes;
    QPushButton* editButton;
    QPushButton* deleteButton;
    QFrame* tileFrame;

    void updateCompletionStyle();
};

#endif // TASKITEMWIDGET_H
