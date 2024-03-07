import { Link } from 'react-router-dom';
function NavBar(){
    return(
        <>
        <nav className="navbar navbar-expand-lg bg-light sticky-top">
        <div className="container-fluid">
            <Link to="/">
              <button data-mdb-ripple-init type="button" className="btn btn-lg">
                EthioRush
                </button>
            </Link>
            <Link to="/About">
              <button data-mdb-ripple-init type="button" className="btn">
                About
                </button>
            </Link>
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
        <Link to='signinasuser'>
        <button data-mdb-ripple-init type="button" className="btn px-3 me-2">
          Sign In
          </button>
          </Link>
        <Link to='choosecreate'>
        <button data-mdb-ripple-init type="button" className="btn btn-dark me-3">
          Sign up
        </button>
        </Link>
      </div>
          </div>
        </div>
      </nav>
        </>
    );
}
export default NavBar;