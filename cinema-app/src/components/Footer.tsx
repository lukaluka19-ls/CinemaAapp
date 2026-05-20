const Footer: React.FC = () => {
  return (
    <footer className="bg-black text-gray-400 border-t border-white/10">
      <div className="max-w-screen-xl mx-auto">
        <div className="flex flex-col md:flex-row justify-between items-center py-1">
          <div className="flex flex-col items-center md:items-start">
            <a
              href="/"
              className="text-white text-2xl font-bold tracking-tight hover:opacity-80 transition-opacity"
            >
              CinemaApp<span className="text-red-500  ">.</span>
            </a>
          </div>
          <nav>
            <ul className="flex flex-wrap justify-center gap-x-8 gap-y-4 text-sm font-medium transition-colors">
              <li>
                <a href="#" className="hover:text-white transition-colors">
                  About Us
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-white transition-colors">
                  Services
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-white transition-colors">
                  Privacy
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-white transition-colors">
                  Contact
                </a>
              </li>
            </ul>
          </nav>
        </div>
      </div>
    </footer>
  );
};
export default Footer;
