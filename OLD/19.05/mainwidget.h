#ifndef MAINWIDGET_H
#define MAINWIDGET_H

#include <QMainWindow>
#include <QTimer>
#include "scene3d.h"
namespace Ui {
class MainWidget;
}

class MainWidget : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWidget(QWidget *parent = 0);
    ~MainWidget();
    
private:
    Ui::MainWidget *ui;
    QWidget *mainWidget;
    QTimer *timer;
};

#endif // MAINWIDGET_H
