export default function SalesChart() {
  const data = [
    { label: "Confirmed", height: "h-32" },
    { label: "Packed", height: "h-40" },
    { label: "Refunded", height: "h-20" },
    { label: "Shipped", height: "h-44" },
  ];

  return (
    <div className="bg-white p-4 rounded-2xl shadow flex flex-col">
      <h2 className="font-semibold mb-4">Sales</h2>
      <div className="flex justify-around items-end h-44">
        {data.map((item) => (
          <div key={item.label} className="flex flex-col items-center">
            <div className={`w-6 bg-blue-400 rounded-t ${item.height}`}></div>
            <span className="text-sm mt-1">{item.label}</span>
          </div>
        ))}
      </div>
    </div>
  );
}
