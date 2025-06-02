#ifndef NOTEITEMWIDGET_H
#define NOTEITEMWIDGET_H

#pragma once
#include <QWidget>
#include <QLabel>
#include <QPushButton>
#include <QHBoxLayout>
#include <QString>
#include <QDate>
#include <QFrame>

class NoteItemWidget : public QWidget {
    Q_OBJECT
public:
    NoteItemWidget(const QString& title, const QString& text, QWidget* parent = nullptr);
signals:
    void editRequested();
    void deleteRequested();

private:
    QLabel* titleLabel;
    QLabel* textLabel;
    QLabel* lengthLabel;
    QPushButton* editButton;
    QPushButton* deleteButton;
};

#endif // NOTEITEMWIDGET_H
