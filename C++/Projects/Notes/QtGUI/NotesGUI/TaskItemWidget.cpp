#include "TaskItemWidget.h"

TaskItemWidget::TaskItemWidget(const QString& title, const std::vector<std::pair<QString, bool>>& subtasks, QWidget* parent)
    : QWidget(parent)
{
    titleLabel = new QLabel("<b>" + title + "</b>");
    titleLabel->setAlignment(Qt::AlignCenter);
    titleLabel->setMinimumHeight(30);
    titleLabel->setMinimumWidth(200);
    titleLabel->setObjectName("labelTaskTitle");

    QVBoxLayout* mainLayout = new QVBoxLayout;
    mainLayout->addWidget(titleLabel);

    tileFrame = new QFrame;
    tileFrame->setObjectName("taskTile");
    tileFrame->setFrameShape(QFrame::StyledPanel);
    tileFrame->setLayout(mainLayout);

    QHBoxLayout* wrapperLayout = new QHBoxLayout(this);
    wrapperLayout->addWidget(tileFrame);
    setLayout(wrapperLayout);

    for (size_t i = 0; i < subtasks.size(); ++i) {
        QCheckBox* checkbox = new QCheckBox(subtasks[i].first);
        checkbox->setChecked(subtasks[i].second);

        checkbox->setMinimumHeight(40);
        checkbox->setMinimumWidth(200);
        checkbox->setObjectName("subtaskCheckbox");

        checkboxes.push_back(checkbox);
        mainLayout->addWidget(checkbox);

        connect(checkbox, &QCheckBox::stateChanged, this, [this, i](int state) {
            emit subtaskToggled(i, state == Qt::Checked);
            updateCompletionStyle();
        });
    }

    editButton = new QPushButton("Edit");
    deleteButton = new QPushButton("Delete");
    editButton->setObjectName("editTaskButton");
    deleteButton->setObjectName("deleteTaskButton");

    editButton->setMinimumSize(80, 30);
    deleteButton->setMinimumSize(80, 30);

    QHBoxLayout* buttonLayout = new QHBoxLayout;
    buttonLayout->addWidget(editButton);
    buttonLayout->addWidget(deleteButton);
    mainLayout->addLayout(buttonLayout);

    connect(editButton, &QPushButton::clicked, this, &TaskItemWidget::editRequested);
    connect(deleteButton, &QPushButton::clicked, this, &TaskItemWidget::deleteRequested);

    updateCompletionStyle();
}

void TaskItemWidget::updateSubtaskState(int index, bool checked) {
    if (index >= 0 && index < static_cast<int>(checkboxes.size())) {
        checkboxes[index]->setChecked(checked);
    }
}

bool TaskItemWidget::isCompleted() const {
    for (const auto& checkbox : checkboxes) {
        if (!checkbox->isChecked())
            return false;
    }
    return true;
}

void TaskItemWidget::updateCompletionStyle() {
    bool completed = isCompleted();
    tileFrame->setProperty("completed", completed);
    tileFrame->style()->unpolish(tileFrame);
    tileFrame->style()->polish(tileFrame);
}
