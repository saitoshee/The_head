#include "scene3d.h"
#include "mainwidget.h"
#include "ui_mainwidget.h"
#include <iostream>
#include <QWidget>
#include <QSizePolicy>


//конструктор главного виджета
MainWidget::MainWidget(QWidget *parent) :

QMainWindow(parent),
ui(new Ui::MainWidget)
{

    ui->setupUi(this);
    ui->centralWidget->setLayout(ui->verticalLayout);
    timer = new QTimer(this);

}

MainWidget::~MainWidget() {
    delete ui;
}




