#include<stdio.h>

int front = -1;
int rear = -1;
int a[5];

void insertLast(int x){
    if(rear<=5){
        a[rear] = x;
        rear++;
    }
    else if(rear == -1 && front == -1){
        a[rear] = x;
        rear++;
        front++;
    }
    else{
        printf("Cant push");
    }
}

void deleteFirst(){
    if(front == rear){
        printf("Cant delete");
    }
    else{
        front++;
    }
}

void display(){
    for(int i = front; i<rear; i++){
        printf("%d ", a[i]);
    }
    printf("\n");
}

void main(){
    insertLast(10);
    insertLast(20);
    insertLast(30);
    insertLast(40);
    insertLast(50);
    display();
    deleteFirst();
    display();
}

