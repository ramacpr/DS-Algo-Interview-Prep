class GraphNode{
    nextNodes = new Array()
    constructor(value){
        this.value = value
    }
    addNext(node){
        this.nextNodes.push(node)
    }
    getNextNodes(){
        return this.nextNodes
    }
}

(function(){
    // input 1
    let graph = new GraphNode(1)
    let n1 = new GraphNode(2)
    let n2 = new GraphNode(3)
    let n3 = new GraphNode(4)
    let n4 = new GraphNode(5)
    graph.addNext(n1)
    graph.addNext(n3)
    n1.addNext(n2)
    n3.addNext(n4)
    console.log('input 1...')
    console.log(getEvenNodeCount(graph))

    // input 2
    graph = new GraphNode(1)
    n2 = new GraphNode(2)
    n3 = new GraphNode(3)
    graph.addNext(n2)
    n2.addNext(n3)
    console.log('input 2...')
    console.log(getEvenNodeCount(graph))

    // input 3
    graph = new GraphNode('a')
    let nb = new GraphNode('b')
    let nc = new GraphNode('c')
    let nd = new GraphNode('d')
    let ne = new GraphNode('e')
    let nf = new GraphNode('f')
    let ng = new GraphNode('g')
    let nh = new GraphNode('h')
    let ni = new GraphNode('i')
    let nj = new GraphNode('j')
    let nk = new GraphNode('k')
    let nl = new GraphNode('l')
    let nm = new GraphNode('m')
    graph.addNext(nb)
    graph.addNext(nc)
    nb.addNext(nd)
    nd.addNext(ng)
    ng.addNext(nj)
    nj.addNext(nm)
    nc.addNext(ne)
    nc.addNext(nf)
    ne.addNext(nh)
    nh.addNext(nk)
    nf.addNext(ni)
    ni.addNext(nl)
    console.log('input 3...')
    console.log(getEvenNodeCount(graph))
})();

function getEvenNodeCount(graph){
    let stack = new Array()
    stack.push(graph)
    let evenOddCount = [0, 0]
    dfsTraversal(stack, true, evenOddCount)
    console.log(evenOddCount)
    let result = evenOddCount[0] * (evenOddCount[0] - 1)
    result += evenOddCount[1] * (evenOddCount[1] - 1)
    result = result / 2
    return result
}

function dfsTraversal(stack, isEvenLevel, evenOddCount){
    if(stack.length > 0){
        let poppedGhNode = stack.pop()
        let nxtGNodes = [...poppedGhNode.nextNodes]
        for(let node of nxtGNodes){
            stack.push(node)
        }
        if(isEvenLevel == true){
            evenOddCount[0]++
        } else {
            evenOddCount[1]++
        }
        dfsTraversal(stack, !isEvenLevel, evenOddCount)
    }
}