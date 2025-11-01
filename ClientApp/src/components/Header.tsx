import { Bell, Settings, User } from "lucide-react";

const Header: React.FC = () => {
  return (
    <div className="flex items-center justify-between bg-white px-6 py-3 shadow">
      <input
        type="text"
        placeholder="Search"
        className="border rounded-lg px-3 py-1 w-1/3 focus:outline-none"
      />
      <div className="flex items-center gap-4">
        <Bell className="text-gray-600 cursor-pointer" />
        <Settings className="text-gray-600 cursor-pointer" />
        <User className="rounded-full bg-gray-200 p-1 cursor-pointer" />
      </div>
    </div>
  );
};

export default Header;
