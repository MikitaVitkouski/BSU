#include "NoteItemWidget.h"

NoteItemWidget::NoteItemWidget(const QString& title, const QString& text, QWidget* parent) : QWidget(parent) {
    titleLabel = new QLabel("<b>" + title + "</b>"); // title
    textLabel = new QLabel(text.left(100)); // note
    QString labelText = "Length of note: " + QString::number(text.length()) + " symbols";
    lengthLabel = new QLabel(labelText, this); // length of note

    titleLabel->setMinimumHeight(30);
    titleLabel->setMinimumWidth(200);
    titleLabel->setObjectName("labelTitle");
    textLabel->setMinimumHeight(200);
    textLabel->setMinimumWidth(400);
    textLabel->setObjectName("labelText");
    lengthLabel->setObjectName("labelLength");
    textLabel->setWordWrap(true); // text not in a single line

    editButton = new QPushButton("Edit");
    deleteButton = new QPushButton("Delete");

    editButton->setMinimumSize(80, 30);
    deleteButton->setMinimumSize(80,30);

    QVBoxLayout* textLayout = new QVBoxLayout;
    textLayout->addWidget(titleLabel);
    textLayout->addWidget(lengthLabel);
    textLayout->addWidget(textLabel);

    QHBoxLayout* mainLayout = new QHBoxLayout(this);
    mainLayout->addLayout(textLayout);
    mainLayout->addWidget(editButton);
    mainLayout->addWidget(deleteButton);
    setLayout(mainLayout);

    connect(editButton, &QPushButton::clicked, this, &NoteItemWidget::editRequested);
    connect(deleteButton, &QPushButton::clicked, this, &NoteItemWidget::deleteRequested);
}
