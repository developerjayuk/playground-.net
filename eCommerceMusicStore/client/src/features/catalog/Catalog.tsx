import agent from "../../app/api/agent";
import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    setLoading(true);

    agent.Catalog.list()
      .then(setProducts)
      .finally(() => setLoading(false));
  }, []);

  return (
    <div>
      <ProductList products={products} />
    </div>
  );
}
