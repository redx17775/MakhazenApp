// src/pages/Home.tsx
import { ShoppingCart, Package, DollarSign, TrendingUp } from "lucide-react";

export default function Home() {
  return (
    <div className="text-gray-800 space-y-6 p-6">
      <h1 className="text-2xl font-semibold">Dashboard</h1>

      {/* Overview Cards */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
        <div className="bg-white p-5 rounded-xl shadow flex items-center gap-4">
          <div className="bg-blue-100 p-3 rounded-lg">
            <ShoppingCart className="text-blue-600" />
          </div>
          <div>
            <p className="text-gray-500 text-sm">Orders</p>
            <p className="text-xl font-semibold">124</p>
          </div>
        </div>

        <div className="bg-white p-5 rounded-xl shadow flex items-center gap-4">
          <div className="bg-green-100 p-3 rounded-lg">
            <Package className="text-green-600" />
          </div>
          <div>
            <p className="text-gray-500 text-sm">Products</p>
            <p className="text-xl font-semibold">52</p>
          </div>
        </div>

        <div className="bg-white p-5 rounded-xl shadow flex items-center gap-4">
          <div className="bg-yellow-100 p-3 rounded-lg">
            <DollarSign className="text-yellow-600" />
          </div>
          <div>
            <p className="text-gray-500 text-sm">Revenue</p>
            <p className="text-xl font-semibold">$12,430</p>
          </div>
        </div>

        <div className="bg-white p-5 rounded-xl shadow flex items-center gap-4">
          <div className="bg-red-100 p-3 rounded-lg">
            <TrendingUp className="text-red-600" />
          </div>
          <div>
            <p className="text-gray-500 text-sm">Growth</p>
            <p className="text-xl font-semibold">+8%</p>
          </div>
        </div>
      </div>

      {/* Recent Activity Table */}
      <div className="bg-white rounded-xl shadow p-5">
        <h2 className="text-lg font-semibold mb-4">Recent Orders</h2>
        <table className="w-full text-sm text-left">
          <thead>
            <tr className="border-b text-gray-600">
              <th className="py-2">Order ID</th>
              <th className="py-2">Customer</th>
              <th className="py-2">Amount</th>
              <th className="py-2">Status</th>
            </tr>
          </thead>
          <tbody>
            <tr className="border-b">
              <td className="py-2">#1234</td>
              <td>John Doe</td>
              <td>$230</td>
              <td><span className="text-green-600 font-semibold">Completed</span></td>
            </tr>
            <tr className="border-b">
              <td className="py-2">#1235</td>
              <td>Jane Smith</td>
              <td>$150</td>
              <td><span className="text-yellow-600 font-semibold">Pending</span></td>
            </tr>
            <tr>
              <td className="py-2">#1236</td>
              <td>Ali Hassan</td>
              <td>$420</td>
              <td><span className="text-red-600 font-semibold">Cancelled</span></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}
