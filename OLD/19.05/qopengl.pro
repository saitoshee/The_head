#-------------------------------------------------
#
# Project created by QtCreator 2013-10-29T00:23:11
#
#-------------------------------------------------

QT       += core gui \
            opengl

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = some_game
TEMPLATE = app


SOURCES += main.cpp\
        mainwidget.cpp \
        scene3d.cpp \
        draw.cpp

HEADERS  += mainwidget.h \
        scene3d.h \
        draw.h

FORMS    += mainwidget.ui

#LIBS += -lglut \
  #      -lGLU

CONFIG += opengl
