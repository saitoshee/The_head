#include<QtGui> //Подключаем модуль QtGui
#include "scene3d.h" //подключаем заголовочный модуль
#include <GL/glu.h>
#include <string>
#include <fstream>
#include <iostream>
#include <algorithm>

#include "draw.h"

Scene3D::Scene3D(QWidget *parent/*= 0*/):QGLWidget(parent) {
    setFormat(QGLFormat(QGL::DepthBuffer)); //Использовать буфер глубины

    timer = new QTimer(this);
    connect(timer, SIGNAL(timeout()), this, SLOT(Update()));



    //передает указатель дальше на объект parent
}

/*virtual*/ void Scene3D::initializeGL(){ //инициализация
    qglClearColor(Qt::white);//цвет для очистки буфера  изображения - здесь просто фон окна.
    glClearDepth( 1.0f );    //разрешить очистку буфера глубины
    glEnable(GL_DEPTH_TEST); //устанавливает режим проверки глубины пикселей
    glDepthFunc( GL_LEQUAL );//тип теста глубины
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_COLOR_MATERIAL);

    float dir[4] = {1, 1, 1, 0};

    glLightfv(GL_LIGHT0, GL_DIFFUSE, dir);
    glLightModelf(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);

    glEnable(GL_NORMALIZE);
    //glEnable(GL_CULL_FACE);  //устанавливает режим, когда строятся  только внешние поверхности

    // запоминаем исходную матрицу проекции
    glGetDoublev(GL_MODELVIEW_MATRIX, lastMatrix);


    // -------переменные----------
    scale = 1.0f;

    pos_x = pos_y = 0.0f;
    pos_z = -45.0f;

    xRot = 0.0f;
    yRot = 0.0f;

    lastPos =  QPoint(0, 0);

    dx = 0;
    dy = 0;
    //----------------------------
    timer->start(20);

}

/*virtual*/ void Scene3D::resizeGL(int width, int height){ //окно виджета

    if(height == 0) {
        height = 1;
    }

    glViewport(0, 0, width, height);

    glMatrixMode(GL_PROJECTION);

    glLoadIdentity();

    GLfloat aspect = width / GLfloat(height);

    gluPerspective(45.0, aspect, 1.0, 100.0);

    glMatrixMode(GL_MODELVIEW);

}


void Scene3D::i_want_3d() {
    calcMatrixRotation();
    glMultMatrixd(lastMatrix);        // умножаем матрцу вида на матрицу вращения - вращаем мир

}

/*virtual*/ void Scene3D::paintGL(){ //рисование
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); //очистка буфера изображения и глубины
    glMatrixMode(GL_MODELVIEW); //устанавливает положение и ориентацию матрице моделирования
    glLoadIdentity(); //загружает единичную матрицу моделирования
    glTranslatef(pos_x, pos_y, pos_z); // переходим в нужную позицию
    i_want_3d();
    glScalef(scale, scale, scale);
    drawObjects();

}

/*virtual*/ void Scene3D::keyPressEvent(QKeyEvent *pe){ //нажатие определенной клавиши
     switch(pe->key()){
        case Qt::Key_Escape :  //По Escape - выход из приложения
        this->close();
        break;
    }

    updateGL();
}

/*virtual*/ void Scene3D::wheelEvent(QWheelEvent *event) {
    if(event->delta() > 0) {
        scale *= 1.1;
    }
    else {
        scale /= 1.1;
    }
    updateGL();
}

/* virtual */ void Scene3D::mousePressEvent(QMouseEvent *event) {
    lastPos = QPoint(event->pos());
}

/* virtual */ void Scene3D::mouseMoveEvent(QMouseEvent *event) {
    dx = event->x() - lastPos.x();
    dy = event->y() - lastPos.y();

    if(event->buttons() & Qt::LeftButton) {
            yRot = 0.15 * dx;
            xRot = 0.15 * dy;
    }
    else {
        if(event->buttons() & Qt::RightButton) {
            pos_x += dx * 0.03;
            pos_y += - dy * 0.03;
        }
    }
    lastPos = QPoint(event->pos());
    updateGL();
}

// функция, которая расчиывает матрицу поворота. Здесь получаем вращения независимые от осей
void Scene3D::calcMatrixRotation() {
        glPushMatrix();

        // загружаем старую матрицу
        glLoadMatrixd(lastMatrix);

        // производим вращения по новым перемещениям мыши, но для базиса старой матрицы
        glRotatef(xRot, lastMatrix[0 * 4 + 0], lastMatrix[1 * 4 + 0], lastMatrix[2 * 4 + 0]);
        glRotatef(yRot, lastMatrix[0 * 4 + 1], lastMatrix[1 * 4 + 1], lastMatrix[2 * 4 + 1]);
        xRot = 0;
        yRot = 0;
        // запоминаем полученную матрицу
        glGetDoublev(GL_MODELVIEW_MATRIX, lastMatrix);

        glPopMatrix();
}


// функция, в которой происходит рисование объектов
void Scene3D::drawObjects() {
    DRAW();
}


void Scene3D :: Update() {
   UPDATE();
   updateGL();
}



