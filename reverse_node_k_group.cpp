#include <iostream>
using namespace std;

struct ListNode
{
    int val;
    ListNode *next;
};

ListNode *createNode(int value, ListNode *nextPter)
{
    ListNode *node = new ListNode;
    node->val = value;
    node->next = nextPter;
    return node;
}

ListNode *addList(ListNode *head, int value)
{
    ListNode *temp = createNode(value, NULL);
    if(head == NULL){
        head = temp;
        return head;
    }

    while (head->next != NULL)
    {
        head = head->next;
    }
    head->next = temp;
    return head;
}

void printList(ListNode *head)
{
    while (head != NULL)
    {
        cout << head->val << ' ';
        head = head->next;
    }
    cout << endl;
}

ListNode *reverseList(ListNode *head)
{
    ListNode *prev = NULL, *current = head, *next;
    while(current != NULL){
        next = current->next;
        current->next = prev;        
        prev = current;
        current = next;
    }
    return prev;
}

ListNode *reverseKGroup(ListNode *head, int k)
{
    ListNode *retLst = createNode(0, head), *revLst, *checkPtNode = retLst;
    while(retLst != NULL)
    {
        cout << "Loop" << endl;
        ListNode *curr = checkPtNode;
        for(int i = 0; i < k; i++){
            curr = curr->next;

            // Check if temp does not get all k nodes
            if(curr == NULL)
                return retLst->next;
        }
        ListNode* oldGrp = checkPtNode->next;
        ListNode* newGrp = curr->next;           // First node of next list
        curr->next = NULL;                      // Split the current list
        printList(checkPtNode);
        printList(oldGrp);
        revLst = reverseList(oldGrp);
        printList(revLst);
        checkPtNode->next = revLst;             // Connect to the reverse list
        printList(checkPtNode);

        // Update
        oldGrp->next = newGrp;       // Connect again to next list
        checkPtNode = oldGrp;
        printList(checkPtNode);
        printList(retLst);
    }
    return retLst->next;
}

int main()
{
    ListNode *head = createNode(1, NULL);
    addList(head, 2);
    addList(head, 3);
    addList(head, 4);
    addList(head, 5);
    addList(head, 6);
    // addList(head, 7);
    // addList(head, 8);
    // addList(head, 9);
    // addList(head, 10);
    head = reverseKGroup(head, 3);
    printList(head);
    return 0;
}