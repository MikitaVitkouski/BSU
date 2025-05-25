#ifndef ALARMITEMWIDGET_H
#define ALARMITEMWIDGET_H

#include <QWidget>
#include <QLabel>
#include <QPushButton>
#include <QHBoxLayout>
#include <QString>

class AlarmItemWidget : public QWidget {
    Q_OBJECT
signals:
    void deleteRequested();
public:
    AlarmItemWidget(const QString& timeText, const QString& labelText, QWidget* parent = nullptr);
private:
    QLabel* labelTime;
    QLabel* labelLabel;
    QPushButton* btnDelete;
};

#endif
