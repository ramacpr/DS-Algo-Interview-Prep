// https://practice.geeksforgeeks.org/problems/move-all-zeros-to-the-front-of-the-linked-list/1

class Node{
    constructor(value){
        this.value = value
        this.nextNode = null
    }

    getNodeValue(){
        return this.value
    }

    addNextNode(next, isGetNextNode){
        this.nextNode = next
        if(isGetNextNode){
            return this.nextNode
        } else {
            return undefined
        }
    }

    getNextNode(){
        return this.nextNode
    }
}

(function(){
    let root = new Node(10)
    root.addNextNode(new Node(12), true).addNextNode(new Node(0), true).addNextNode(new Node(1), true).addNextNode(new Node(0), true).addNextNode(new Node(23), true)
    console.log('Input:')
    printList(root)
    root = moveZeroNodes(root)
    console.log('Output:')
    printList(root)
})();


function printList(root){
    let curr = root
    let printstring = '';
    while(curr){
        printstring += curr.getNodeValue() + ' '
        curr = curr.getNextNode()
    }
    console.log(printstring)
}

function moveZeroNodes(root){
    let headNode = root
    let currNode = root, prevNode = null

    while(currNode != null){
        if(currNode.getNodeValue() == 0 && currNode != headNode){
            // reposition this node at head
            // and connect previous node to next 
            prevNode.addNextNode(currNode.getNextNode())
            currNode.addNextNode(headNode)
            headNode = currNode
            currNode = prevNode.getNextNode()
            continue
        }
        prevNode = currNode
        currNode = currNode.getNextNode()
    }
    return headNode
}
