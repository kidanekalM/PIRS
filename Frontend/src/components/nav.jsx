function NavBar(){
    return(
        <>
        <nav className="navbar navbar-expand-lg bg-light sticky-top">
        <div className="container-fluid">
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
            <ul className="navbar-nav  me-auto mb-2 mb-lg-0">
            </ul>
                  <div className="d-flex align-items-center">
        <button data-mdb-ripple-init type="button" className="btn px-3 me-2">
          Login
        </button>
        <button data-mdb-ripple-init type="button" className="btn btn-dark me-3">
          Sign up for free
        </button>
      </div>
          </div>
        </div>
      </nav>
        </>
    );
}
export default NavBar;