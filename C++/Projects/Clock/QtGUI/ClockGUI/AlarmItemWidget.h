#ifndef ALARMITEMWIDGET_H
#define ALARMITEMWIDGET_H

#include <QWidget>
#include <QLabel>
#include <QPushButton>
#include <QHBoxLayout>
#include <QString>
#include <QCheckBox>

class AlarmItemWidget : public QWidget {
    Q_OBJECT
signals:
    void deleteRequested();
    void onAlarmToggled(bool enabled);
public:
    AlarmItemWidget(const QString& timeText, const QString& labelText, bool isEnabled, QWidget* parent = nullptr);
    void setEnabledState(bool state);
private:
    QLabel* labelTime;
    QLabel* labelLabel;
    QPushButton* btnDelete;
    QCheckBox* toggleSwitch;
};

#endif
