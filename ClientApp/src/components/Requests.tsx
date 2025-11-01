export default function Requests() {
  const requests = [
    { label: "REFUNDS", value: 12, color: "text-red-600" },
    { label: "MESSAGE", value: 1 },
    { label: "NEW ITEMS", value: 67 },
    { label: "NEW ORDERS", value: 190, color: "text-blue-600" },
    { label: "MISSING ITEMS", value: 11 },
  ];

  return (
    <div className="grid grid-cols-5 gap-4 mt-6">
      {requests.map((r) => (
        <div key={r.label} className="bg-white rounded-2xl shadow p-4 flex flex-col items-center">
          <span className={`text-2xl font-bold ${r.color || ""}`}>{r.value}</span>
          <span className="text-sm mt-1">{r.label}</span>
        </div>
      ))}
    </div>
  );
}
