#include "TaskItemWidget.h"

TaskItemWidget::TaskItemWidget(const QString& title, const std::vector<std::pair<QString, bool>>& subtasks, QWidget* parent)
    : QWidget(parent)
{
    titleLabel = new QLabel("<b>" + title + "</b>");
    titleLabel->setAlignment(Qt::AlignCenter);

    QVBoxLayout* mainLayout = new QVBoxLayout;
    mainLayout->addWidget(titleLabel);

    for (size_t i = 0; i < subtasks.size(); ++i) {
        QCheckBox* checkbox = new QCheckBox(subtasks[i].first);
        checkbox->setChecked(subtasks[i].second);
        checkboxes.push_back(checkbox);
        mainLayout->addWidget(checkbox);

        connect(checkbox, &QCheckBox::stateChanged, this, [this]() {
            // Optional: update UI or emit signal if completed
        });
    }

    editButton = new QPushButton("Edit");
    deleteButton = new QPushButton("Delete");

    QHBoxLayout* buttonLayout = new QHBoxLayout;
    buttonLayout->addWidget(editButton);
    buttonLayout->addWidget(deleteButton);

    mainLayout->addLayout(buttonLayout);
    setLayout(mainLayout);

    connect(editButton, &QPushButton::clicked, this, &TaskItemWidget::editRequested);
    connect(deleteButton, &QPushButton::clicked, this, &TaskItemWidget::deleteRequested);
}

void TaskItemWidget::updateSubtaskState(int index, bool checked) {
    if (index >= 0 && index < static_cast<int>(checkboxes.size())) {
        checkboxes[index]->setChecked(checked);
    }
}

bool TaskItemWidget::isCompleted() const {
    for (const auto& checkbox : checkboxes) {
        if (!checkbox->isChecked()) return false;
    }
    return true;
}
