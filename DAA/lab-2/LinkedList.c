#include<stdio.h>
#include<stdlib.h>

struct Node
{
    int data;
    struct Node* next;
};

struct Node* head = NULL;

void insertFirst(int x){
    struct Node* newNode = (struct Node *)(malloc(sizeof(struct Node)));

    newNode->data = x;
    newNode->next = head;

    head = newNode;
}

void insertLast(int x){
    struct Node* newNode = (struct Node *)(malloc(sizeof(struct Node)));

    newNode->data = x;
    newNode->next = NULL;

    if(head == NULL){
        head = newNode;

    }
    else{
        struct Node* temp = head;
        while(temp->next != NULL){
            temp = temp->next;
        }
        temp->next = newNode;
    }
}

void display(){
    struct Node* temp = head;
    while(temp != NULL){
        if(temp->next == NULL){
            printf("%d\n", temp->data);
        }
        else{
            printf("%d -> ", temp->data);
        }
        
        temp = temp->next;
    }
}

void deleteLast(){
    
    if(head == NULL){
       printf("Empty");

    }
    else{
        struct Node* temp = head;
        while(temp->next->next != NULL){
            temp = temp->next;
        }
        temp->next = NULL;
    }
}

void deleteFirst(){
    head = head->next;
}

void deleteSp(int pos){
    struct Node* temp = head;

    for(int i = 0; i<pos; i++){
        temp = temp->next;
    }
    temp->next = temp->next->next;
}

void main(){
    insertLast(10);
    insertLast(20);
    insertLast(30);
    insertLast(40);
    display();
    deleteLast();
    display();
    deleteFirst();
    display();
    insertFirst(10);
    display();
}