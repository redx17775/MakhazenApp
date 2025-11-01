// src/components/Sidebar.tsx
import { Link, useLocation } from "react-router-dom";
import { Home, Box, Layers, Store, DollarSign, Settings, PlusCircle, LogOut } from "lucide-react";

export default function Sidebar() {
  const location = useLocation();

  const linkClass = (path: string) =>
    `flex items-center gap-3 p-3 rounded-lg transition ${
      location.pathname === path
        ? "bg-white text-blue-700 font-semibold"
        : "text-white hover:bg-blue-500"
    }`;

  return (
    <aside className="w-60 bg-blue-700 text-white flex flex-col justify-between p-4">
      <div>
        <h1 className="text-2xl font-bold mb-8">Makhazen </h1>
        <nav className="flex flex-col gap-3">
          <Link to="/" className={linkClass("/")}>
            <Home size={18} /> Home
          </Link>
          <Link to="/products" className={linkClass("/products")}>
            <Box size={18} /> Products
          </Link>
          <Link to="/categories" className={linkClass("/categories")}>
            <Layers size={18} /> Categories
          </Link>
          <Link to="/stores" className={linkClass("/stores")}>
            <Store size={18} /> Stores
          </Link>
          <Link to="/finances" className={linkClass("/finances")}>
            <DollarSign size={18} /> Finances
          </Link>
          <Link to="/settings" className={linkClass("/settings")}>
            <Settings size={18} /> Settings
          </Link>
        </nav>
      </div>

      <div className="flex flex-col gap-3">
        <Link to="/add-product" className={"p-0"}>
          <button className="flex items-center gap-2 bg-blue-500 hover:bg-blue-400 rounded-lg px-3 py-2 text-sm">
            <PlusCircle size={16} /> Add Product
          </button>
        </Link>
        <button className="flex items-center gap-2 hover:text-gray-300 text-sm">
          <LogOut size={16} /> Log out
        </button>
      </div>
    </aside>
  );
}
