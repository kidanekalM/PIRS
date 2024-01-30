function NavBar(){
    return(
        <>
        <nav className="navbar navbar-expand-lg bg-light">
        <div className="container">
          <a className="navbar-brand">
            EthioRush
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNavDropdown"
            aria-controls="navbarNavDropdown"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id='navbarNavDropdown'>
            <ul className="navbar-nav">
              <li className="nav-item">
                <a className="nav-link active" aria-current="page"
                  >Home</a>
              </li>
              <li className="nav-item">
                <a className="nav-link" 
                  >Reports</a>
              </li>
              <li className="nav-item">
                <a className="nav-link">Profile</a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
        </>
    );
}
export default NavBar;