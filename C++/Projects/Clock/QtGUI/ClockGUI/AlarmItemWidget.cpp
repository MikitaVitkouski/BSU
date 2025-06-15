#include "AlarmItemWidget.h"

AlarmItemWidget::AlarmItemWidget(const QString& timeText, const QString& labelText, bool isEnabled, QWidget* parent) : QWidget(parent) {
    labelTime = new QLabel(timeText);
    labelLabel = new QLabel(labelText);
    btnDelete = new QPushButton("Delete");
    toggleSwitch = new QCheckBox("ON");

    labelTime->setMinimumHeight(30);
    labelTime->setMinimumWidth(50);
    labelLabel->setMinimumHeight(50);
    labelLabel->setMinimumWidth(50);
    btnDelete->setMinimumHeight(30);
    btnDelete->setMinimumWidth(50);

    toggleSwitch->setChecked(isEnabled);
    toggleSwitch->setObjectName("alarmToggle");
    labelTime->setObjectName("alarmLabelTime");
    labelLabel->setObjectName("alarmLabelText");
    btnDelete->setObjectName("alarmDeleteButton");

    connect(toggleSwitch, &QCheckBox::toggled, this, &AlarmItemWidget::onAlarmToggled);
    connect(btnDelete, &QPushButton::clicked, this, &AlarmItemWidget::deleteRequested);

    QVBoxLayout* textLayout = new QVBoxLayout;
    textLayout->addWidget(labelTime);
    textLayout->addWidget(labelLabel);

    QHBoxLayout* layout = new QHBoxLayout(this);
    layout->addLayout(textLayout);
    layout->addStretch();
    layout->addWidget(btnDelete);
    layout->addWidget(toggleSwitch);
}

void AlarmItemWidget::setEnabledState(bool state) {
    if (toggleSwitch->isChecked() != state) {
        toggleSwitch->setChecked(state);
    }
}
