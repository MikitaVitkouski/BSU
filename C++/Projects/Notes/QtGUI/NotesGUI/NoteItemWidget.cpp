#include "NoteItemWidget.h"

NoteItemWidget::NoteItemWidget(const QString& title, const QString& text, QWidget* parent) : QWidget(parent) {
    titleLabel = new QLabel("<b>" + title + "</b>");
    textLabel = new QLabel(text.left(100).replace("\n", " "));

    titleLabel->setMinimumHeight(30);
    titleLabel->setMinimumWidth(200);
    titleLabel->setObjectName("labelTitle");
    textLabel->setMinimumHeight(100);
    textLabel->setMinimumWidth(200);
    textLabel->setObjectName("labelText");

    editButton = new QPushButton("Edit");
    deleteButton = new QPushButton("Delete");

    editButton->setMinimumSize(80, 30);
    deleteButton->setMinimumSize(80,30);

    QVBoxLayout* textLayout = new QVBoxLayout;
    textLayout->addWidget(titleLabel);
    textLayout->addWidget(textLabel);

    QHBoxLayout* mainLayout = new QHBoxLayout(this);
    mainLayout->addLayout(textLayout);
    mainLayout->addWidget(editButton);
    mainLayout->addWidget(deleteButton);
    setLayout(mainLayout);

    connect(editButton, &QPushButton::clicked, this, &NoteItemWidget::editRequested);
    connect(deleteButton, &QPushButton::clicked, this, &NoteItemWidget::deleteRequested);
}
