import axios from "axios";
import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    getProducts();
  }, []);

  async function getProducts() {
    const products = await axios.get<Product[]>(
      "http://localhost:5195/api/products"
    );

    setProducts(products.data);
  }

  return (
    <div>
      <ProductList products={products} />
    </div>
  );
}
