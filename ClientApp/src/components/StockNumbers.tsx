export default function StockNumbers() {
  return (
    <div className="bg-white p-4 rounded-2xl shadow flex flex-col gap-2">
      <h2 className="font-semibold mb-2">Stock numbers</h2>
      <p className="text-red-600">Low stock items: <span className="font-bold">12</span></p>
      <p>Item categories: 6</p>
      <p>Refunded items: 1</p>
    </div>
  );
}
