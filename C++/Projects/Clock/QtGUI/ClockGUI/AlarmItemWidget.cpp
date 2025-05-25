#include "AlarmItemWidget.h"

AlarmItemWidget::AlarmItemWidget(const QString& timeText, const QString& labelText, QWidget* parent) : QWidget(parent) {
    labelTime = new QLabel(timeText);
    labelLabel = new QLabel(labelText);
    btnDelete = new QPushButton("Delete");

    labelTime->setObjectName("alarmLabelTime");
    labelLabel->setObjectName("alarmLabelText");
    btnDelete->setObjectName("alarmDeleteButton");

    QVBoxLayout* textLayout = new QVBoxLayout;
    textLayout->addWidget(labelTime);
    textLayout->addWidget(labelLabel);

    QHBoxLayout* layout = new QHBoxLayout(this);
    layout->addLayout(textLayout);
    layout->addStretch();
    layout->addWidget(btnDelete);

    connect(btnDelete, &QPushButton::clicked, this, &AlarmItemWidget::deleteRequested);
}
