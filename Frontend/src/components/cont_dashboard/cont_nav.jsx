import {Link} from 'react-router-dom'
const ContNav = () => {
    return ( 
        <nav className="navbar navbar-expand-lg sticky-top bg-light">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
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
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav">
              <li className="nav-item">
              <Link to='../contdashboard'>
              <button data-mdb-ripple-init type="button" className="btn">
                  Home
                </button>
              </Link>
              </li>
              <li className="nav-item">
              <Link to='../contprofile'>
              <button data-mdb-ripple-init type="button" className="btn">
                  Profile
                </button> 
              </Link>
              </li>
              <li className="nav-item">
                <Link to='../'>                
                <button data-mdb-ripple-init type="button" className="btn">
                  Log Out
                </button> 
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
     );
}
 
export default ContNav;