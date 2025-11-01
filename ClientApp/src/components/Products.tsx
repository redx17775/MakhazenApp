interface Product {
  id: number;
  image: string;
  name: string;
  status: "Active" | "Sold out" | "Low stock";
  stock: string;
  category: string;
  location: string;
}

const products: Product[] = [
  { id: 1, image: "/img1.jpg", name: "Unisex T-Shirt White", status: "Active", stock: "10 in stock", category: "T-shirts", location: "4 stores" },
  { id: 2, image: "/img2.jpg", name: "Unisex T-Shirt Black", status: "Active", stock: "10 in stock", category: "T-shirts", location: "4 stores" },
  { id: 3, image: "/img3.jpg", name: "Tank Top White", status: "Active", stock: "28 in stock", category: "Tops", location: "3 stores" },
  { id: 4, image: "/img4.jpg", name: "Rain Jacket Male", status: "Active", stock: "12 in stock", category: "Outerwear", location: "3 stores" },
  { id: 5, image: "/img5.jpg", name: "Bomber Jacket Male", status: "Sold out", stock: "0 in stock", category: "Outerwear", location: "0 stores" },
  { id: 6, image: "/img6.jpg", name: "Unisex Socks Black", status: "Active", stock: "37 in stock", category: "Accessories", location: "2 stores" },
  { id: 7, image: "/img7.jpg", name: "Denim Shorts Women", status: "Low stock", stock: "1 in stock", category: "Bottoms", location: "1 store" },
  { id: 8, image: "/img8.jpg", name: "Summer Dress Black", status: "Sold out", stock: "0 in stock", category: "Dresses", location: "0 stores" },
  { id: 9, image: "/img9.jpg", name: "Kids T-shirt Pink", status: "Low stock", stock: "1 in stock", category: "T-shirts", location: "1 store" },
];

const Products: React.FC = () => {
  return (
    <div>
      <div className="flex justify-between items-center mb-4">
        <h1 className="text-xl font-semibold">Products</h1>
        <button className="bg-blue-600 hover:bg-blue-500 text-white px-4 py-2 rounded-lg">
          + Add product
        </button>
      </div>

      <div className="bg-white rounded-2xl shadow p-4">
        <div className="flex justify-between mb-4">
          <input
            type="text"
            placeholder="Search"
            className="border rounded-lg px-3 py-1 w-1/3 focus:outline-none"
          />
          <select className="border rounded-lg px-3 py-1">
            <option>Filter by</option>
            <option>Active</option>
            <option>Sold out</option>
            <option>Low stock</option>
          </select>
        </div>

        <table className="w-full text-left border-collapse">
          <thead>
            <tr className="text-gray-600 border-b">
              <th className="py-2 pl-2"></th>
              <th className="py-2">Name of product</th>
              <th className="py-2">Status</th>
              <th className="py-2">Stock info</th>
              <th className="py-2">Category</th>
              <th className="py-2">Location</th>
            </tr>
          </thead>
          <tbody>
            {products.map((p) => (
              <tr key={p.id} className="border-b last:border-0 hover:bg-gray-50">
                <td className="py-2 pl-2">
                  <input type="checkbox" />
                </td>
                <td className="flex items-center gap-3 py-2">
                  <img
                    src={p.image}
                    alt={p.name}
                    className="w-12 h-12 rounded-lg object-cover"
                  />
                  <span>{p.name}</span>
                </td>
                <td>
                  <span
                    className={`px-3 py-1 rounded-full text-sm ${
                      p.status === "Active"
                        ? "bg-blue-100 text-blue-700"
                        : p.status === "Sold out"
                        ? "bg-gray-200 text-gray-700"
                        : "bg-black text-white"
                    }`}
                  >
                    {p.status}
                  </span>
                </td>
                <td>{p.stock}</td>
                <td>{p.category}</td>
                <td>{p.location}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Products;
