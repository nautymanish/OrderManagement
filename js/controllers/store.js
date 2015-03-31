//----------------------------------------------------------------
// store (contains the products)
//

//



function store() {
    this.products = [];//[new product("A","A","a",1), new product("b","b","b",2)];
    
}
store.prototype.getProduct = function (sku) {
    for (var i = 0; i < this.products.length; i++) {
        if (this.products[i].sku == sku)
            return this.products[i];
    }
    return null;
}

