#ifndef SCENE3D_H
#define SCENE3D_H

#include <QGLWidget>
#include <QTimer>
#include <vector>

class Scene3D : public QGLWidget{
    Q_OBJECT

private:
    //------interface opengl-----//
    GLfloat scale;
    GLfloat pos_x, pos_y, pos_z;
    QPoint lastPos;
    GLfloat dx, dy;
    GLfloat xRot, yRot;
    GLdouble lastMatrix[16];

    //--------------------------//




public:
    QTimer *timer;

    explicit Scene3D(QWidget *parent = 0);                //конструктор класса( = 0 -- главное окно)



public slots:
    void Update();



protected:
    /*virtual*/ void initializeGL();                     //метод для проведения инициализаций, связанных с OpenGL.
    /*virtual*/ void resizeGL(int nWidth, int nHeight); //метод вызывается при изменении размеров окна
    /*virtual*/ void paintGL();                            //метод, что бы заново перерисовать содержимое виджета
    /*virtual*/ void wheelEvent(QWheelEvent * event);      //метод обратки вращение колесом мыши
    /*virtual*/ void keyPressEvent(QKeyEvent *pe);        //метод обработки нажатия определенной клавиши
    /*virtual*/ void mousePressEvent(QMouseEvent *event); //метод обработки нажатия мыши
    /*virtual*/ void mouseMoveEvent(QMouseEvent *event);  //метод обработки движения мыши

    void calcMatrixRotation();                            // вычисления матрицы вращения
    void drawObjects();                                   // метод, рисующий объекты
    void i_want_3d();

};


#endif // SCENE3D_H
