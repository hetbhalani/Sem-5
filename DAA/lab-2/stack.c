#include<stdio.h>

int top = -1;
int a[5];

void push(int x){
    if(top<=5){
        a[top] = x;
        top++;
    }
    else{
        printf("Cant push");
    }
}

void pop(){
    if(top == -1){
        printf("Cant pop");
    }
    else{
        top--;
        printf("%d", a[top]);
    }
}

void peek(){
    if(top == -1){
        printf("Cant pop");
    }
    else{
        printf("%d", a[top]);
    }
}

void main(){
    push(10);
    push(20);
    push(30);
    push(40);
    pop();
    pop();
}

