#include <GL/gl.h>
#include <GL/glu.h>
#include <iostream>
#include "draw.h"
#include <cmath>

using namespace std;
double t=2;
double an,bn,xs=0.5,ys=0.5,zs=0.5, Xs,Ys,Zs;
void draw_line(double Ax, double Ay, double Bx, double By) {
    glBegin(GL_LINES);
    glVertex2d(Ax, Ay);
    glVertex2d(Bx, By);
    glEnd();
}

void draw_topc(double r, double x, double y, double z){
    double Ax,Ay;
    double dphi=0.3;
    glNormal3d(0,0,-1);
    glBegin(GL_POLYGON);
    for(double phi=0; phi<2*3.1415; phi+=dphi){
        Ax=x + r*sin(phi);
        Ay=y + r*cos(phi);
        glVertex3d(Ax,Ay,z);
    }
    glEnd();

}

void draw_botc(double r, double x, double y, double z){
    double Ax,Ay;
    double dphi=0.3;
    glNormal3d(0,0,-1);
    glBegin(GL_POLYGON);
    for(double phi=0; phi<2*3.1415; phi+=dphi){
        Ax=x - r*sin(phi);
        Ay=y - r*cos(phi);
        glVertex3d(Ax,Ay,z);
    }
    glEnd();

}
void draw_cyr(double r, double x, double y, double h){
    double Ax,Ay,Bx,By,Az,Bz;
    double dphi=0.05;
    for(double phi=0; phi<2*3.1415; phi+=dphi){
        Ax=x + r*sin(phi);
        Ay=y + r*cos(phi);
        Az=0;
        Bz=h;
        Bx=x + r*sin(phi+dphi);
        By=y + r*cos(phi+dphi);
        glNormal3d(Ax, Ay, 0);
        glBegin(GL_POLYGON);
        glVertex3d(Ax,Ay,Az);
        glVertex3d(Ax,Ay,Bz);
        glVertex3d(Bx,By,Bz);
        glVertex3d(Bx,By,Az);
        glEnd();

    }
    //draw_topc(r, x, y, h);
    draw_botc(r,x,y,h);
}

void draw_p(double xmin, double xmax, double ymin, double ymax, double zmin, double zmax){

    // z
    glNormal3d(0, 0, 1);
    glBegin(GL_POLYGON);
    glVertex3d(xmin, ymin, zmin);
    glVertex3d(xmax, ymin, zmin);
    glVertex3d(xmax, ymax, zmin);
    glVertex3d(xmin, ymax, zmin);
    glEnd();
    glNormal3d(0, 0, 1);
    glBegin(GL_POLYGON);
    glVertex3d(xmin, ymin, zmax);
    glVertex3d(xmax, ymin, zmax);
    glVertex3d(xmax, ymax, zmax);
    glVertex3d(xmin, ymax, zmax);
    glEnd();

    //y
    glNormal3d(0,-1,0);
    glBegin(GL_POLYGON);
    glVertex3d(xmin, ymax, zmin);
    glVertex3d(xmax, ymax, zmin);
    glVertex3d(xmax, ymax, zmax);
    glVertex3d(xmin, ymax, zmax);
    glEnd();

    glBegin(GL_POLYGON);
    glVertex3d(xmin, ymin, zmin);
    glVertex3d(xmin, ymin, zmax);
    glVertex3d(xmax, ymin, zmax);
    glVertex3d(xmax, ymin, zmin);
    glEnd();

    //x
    glNormal3d(1,0,0);
    glBegin(GL_POLYGON);
    glVertex3d(xmin, ymin, zmin);
    glVertex3d(xmin, ymin, zmax);
    glVertex3d(xmin,ymax, zmax);
    glVertex3d(xmin, ymax, zmin);
    glEnd();

    glBegin(GL_POLYGON);
    glVertex3d(xmax, ymin, zmin);
    glVertex3d(xmax, ymin, zmax);
    glVertex3d(xmax, ymax, zmax);
    glVertex3d(xmax, ymax, zmin);
    glEnd();
}

double R(){
    double r;
    r=1;
    return r;
}
void draw_sp(double tet, double ph, double dph, double dtet,double xs,double ys,double zs){

  double x, y, z,x1,x2,x3,y1,y2,y3,z1,z2,z3;
  double r,r1,r2,r3;
  r= R();
  x=xs+r*sin(tet)*sin(ph);
  y=ys+r*sin(tet)*cos(ph);
  z=zs+r*cos(tet);

  r1= R();
  x1=xs+r1*sin(tet)*sin(ph+dph);
  y1=ys+r1*sin(tet)*cos(ph+dph);
  z1=zs+r1*cos(tet);

  r2=R();
  x2=xs+r2*sin(tet+dtet)*sin(ph+dph);
  y2=ys+r2*sin(tet+dtet)*cos(ph+dph);
  z2=zs+r2*cos(tet+dtet);

  r3=R();
  x3=xs+r3*sin(tet+dtet)*sin(ph);
  y3=ys+r3*sin(tet+dtet)*cos(ph);
  z3=zs+r3*cos(tet+dtet);

  glBegin(GL_LINE_LOOP);
  glVertex3d(x,y,z);
  glVertex3d(x1,y1,z1);
  glVertex3d(x2,y2,z2);
  glVertex3d(x3,y3,z3);
  glEnd();
}

void draw_spher(double xs,double ys,double zs){
    double dtet=0.07,dph=0.07;
    for(double tet = 0;tet<=M_PI; tet+=dtet){
        for(double ph = 0;ph<=2*M_PI; ph+=dph){
            draw_sp(tet,ph,dtet,dph,xs,ys,zs);
        }
    }
}

void draw_pndlm(){
  glColor3d(0,0.5,0);
    draw_cyr(0.5,0,1,25);
    draw_p(0,11,1.5,0.5,25,24);
    draw_spher(11,0,15);

    glBegin(GL_LINE_LOOP);
    glVertex3d(11,0,15);
    glVertex3d(10,1,25);

    glEnd();
}

void DRAW() {
    float pos[3] = {10, 10, 10};
    glLightfv(GL_LIGHT0, GL_POSITION, pos);
  //draw_pndlm();
   draw_pndlm();
}

void UPDATE() {
xs+=0.2;
ys-=0.09;
}
